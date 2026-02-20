using UnityEngine;
using Unity.Netcode;

public class Switch : NetworkBehaviour
{
    [SerializeField] private NetworkDoor door;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsOwner) return;
        if (other.CompareTag("Player"))
        {
            door.OpenDoorServerRpc();
            PlaySoundClientRpc();
        }

        //if (!other.CompareTag("Player")) return;

    }

    [ClientRpc]
    private void PlaySoundClientRpc()
    {
        AudioManager.instance.PlayDoorSFX();
    }
}
