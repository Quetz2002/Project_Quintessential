using UnityEngine;
using Unity.Netcode;

public class Spawner : NetworkBehaviour
{

    [SerializeField] private GameObject _spawner;

    public override void OnNetworkDespawn()
    {
        if (!IsServer) return;

        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void Generate () 
    {
        GameObject gameObject = Instantiate(_spawner);
        gameObject.GetComponent<NetworkObject>().Spawn();
    }
}
