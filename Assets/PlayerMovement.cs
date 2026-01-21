using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 25f;

    private void Update()
    {
        if (!IsOwner) return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0, z) * speed * Time.deltaTime;

        MoveServerRPC(move);
    
    }
    [ServerRpc]
    void MoveServerRPC(Vector3 move)
    {
        transform.Translate(move);
    }
}
