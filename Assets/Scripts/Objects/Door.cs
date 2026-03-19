using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    GameObject doorOpenPrefab;
    public void OpenDoor()
   {
     doorOpenPrefab.SetActive(false);
    }
}
