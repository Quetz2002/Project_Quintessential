using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class CollectibleItem : NetworkBehaviour
{
    private Renderer rend;

    public NetworkVariable<bool> isCollected = new NetworkVariable<bool>(
        false,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server);

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public override void OnNetworkSpawn()
    {
        UpdateVisual(isCollected.Value);

        isCollected.OnValueChanged += OnCollectedChange;
    }

    void OnCollectedChange(bool old, bool newValue)
    {
        UpdateVisual(newValue);
    }

    void UpdateVisual(bool collected)
    {
        rend.enabled = !collected;
    }

    [Rpc(SendTo.Server)]
    public void CollectServerRpc()
    {
        if(isCollected.Value) return;
        isCollected.Value = true;

        ulong playerID = this.GetComponent<NetworkObject>().OwnerClientId;
        ShowCollectedMessageClientRpc(playerID);

        this.GetComponent<NetworkObject>().Despawn();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsServer) return;

        if(isCollected.Value) return;

        if(other.CompareTag("Player"))
        {
            CollectServerRpc();
            //Destroy(this.gameObject);
            
           
        }
    }
    [ClientRpc]
    private void ShowCollectedMessageClientRpc(ulong playerID)
    {
        if (UIMessageManager.instance != null)
        {
            UIMessageManager.instance.ShowMessage($"El jugador {playerID} recolectó un objeto");
        }
    }
}
