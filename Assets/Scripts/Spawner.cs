using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

public class Spawner : NetworkBehaviour
{
    [SerializeField]
    private GameObject _item;

    public List<GameObject> _spawnLocations = new List<GameObject>();

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (_spawnLocations == null)
        {
            Debug.LogWarning("No spawn locations");
            return;
        }

        // Get 4 random spawn locations
        List<GameObject> selectedLocations = _spawnLocations
            .OrderBy(x => Random.value)
            .Take(4)
            .ToList();

        // Spawn collectibles at the selected locations
        foreach (GameObject spawnPoint in selectedLocations)
        {
            if (spawnPoint != null)
            {
                GameObject obj = Instantiate(_item, spawnPoint.transform.position, Quaternion.identity);
                obj.GetComponent<NetworkObject>().Spawn();
            }
        }
    }
}
