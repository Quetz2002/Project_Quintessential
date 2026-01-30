using UnityEngine;
using Unity.Netcode;


public class CollectibleItem : NetworkBehaviour
{
    private Renderer rend;

    public NetworkVariable<bool> isCollected = new NetworkVariable<bool>(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public override void OnNetworkSpawn()
    {
        UpdateVisual(isCollected.Value);

        isCollected.OnValueChanged += OnCollectedChanged;
    }

    void OnCollectedChanged(bool previousValue, bool newValue)
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
        if (isCollected.Value) return;

        isCollected.Value = true;
    }
}