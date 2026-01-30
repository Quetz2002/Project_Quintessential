using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;


    private void Update()
    {
        if (!IsOwner) return;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z) * speed * Time.deltaTime;

        MoveServerRPC(move);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryToCollect();
        }
    }

    [ServerRpc]
    void MoveServerRPC(Vector3 move)
    {
        transform.Translate(move);
    }

    void TryToCollect()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider hit in hits)
        {
            CollectibleItem collectible = hit.GetComponent<CollectibleItem>();
            if (collectible != null)
            {
                collectible.CollectServerRpc();
            }
        }
    }
}