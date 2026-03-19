using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
public class RequestSpawn : NetworkBehaviour
{
    [SerializeField] public Spawner spawner;
    [SerializeField] public Transform pos;


    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        pos = GameObject.Find("Spawner").transform;
    }
    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RequestSpawnServerRpc();
        }
    }

    [ServerRpc]
    void RequestSpawnServerRpc()
    {
        spawner.SpawnObject();
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
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        pos = GameObject.Find("Spawner").transform;
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
