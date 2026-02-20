using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

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
        Collider[] hits = Physics.OverlapSphere(transform.position, 1.5f);

        foreach (Collider hit in hits)
        {
            CollectibleItem collectible = hit.GetComponent<CollectibleItem>();
            if (collectible != null)
            {
                collectible.CollectServerRpc();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    private void OnSceneLoaded(ulong clientID, string sceneName, LoadSceneMode mode)
    {
        if (sceneName == "SampleScene")
        {
            AsignarReferencia();
        }
    }

    void AsignarReferencia()
    {
       var aux = this.gameObject.GetComponent<RequestSpawn>();
        aux.enabled = true;
        aux.spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        aux.pos = GameObject.Find("Spawner").transform;
    }

    private void OnEnable()
    {
        NetworkManager.Singleton.SceneManager.OnLoadComplete += OnSceneLoaded;
    }

    private void OnDisable()
    {
        NetworkManager.Singleton.SceneManager.OnLoadComplete -= OnSceneLoaded;
    }
}
