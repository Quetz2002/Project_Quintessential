using UnityEngine;
using Unity.Netcode;

public class PlayerApperence : NetworkBehaviour
{
        private Renderer renderer;
    public NetworkVariable<Color> playerColor 
        = new NetworkVariable<Color>(
            Color.gray,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server);

    public void Awake()
    {
       renderer = GetComponent<Renderer>();
    }
    public override void OnNetworkSpawn()
    {
        
        if(IsServer)
        {
            if(OwnerClientId == 0)
            {
                playerColor.Value = Color.green;
            }
            else
            {
                playerColor.Value = Color.red;
            }
            

        }
       renderer.material.color = playerColor.Value;
        playerColor.OnValueChanged += OnColorChanged;
    }
    
    void OnColorChanged(Color oldColor, Color newColor)
    {
        renderer.material.color = newColor;
    }
}
