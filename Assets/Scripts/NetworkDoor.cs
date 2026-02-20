using UnityEngine;
using Unity.Netcode;
public class NetworkDoor : NetworkBehaviour
{
    [SerializeField] private Transform DoorTransform;
    [SerializeField] private Vector3 openDoor = new Vector3(0, 90, 0);
    [SerializeField] private Vector3 closeDoor = Vector3.zero;

    private NetworkVariable<bool> isOpen = new NetworkVariable<bool>(false);

    public override void OnNetworkSpawn()
    {
        isOpen.OnValueChanged += OnDoorStateChanged;
    }

    void OnDoorStateChanged(bool old, bool newest)
    {
        if (newest)
        {
            DoorTransform.localRotation = Quaternion.Euler(openDoor);
        }
        else
        {
            DoorTransform.localRotation = Quaternion.Euler(closeDoor);
        }
    }

    [Rpc(SendTo.Server)]
    public void OpenDoorServerRpc()
    {
        isOpen.Value = !isOpen.Value;
    }

}
