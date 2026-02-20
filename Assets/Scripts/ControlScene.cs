using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReturnToLobby();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            LeaveGame();
        }
    }
    public void ReturnToLobby()
    {
        if (!NetworkManager.Singleton.IsHost) return;

        NetworkManager.Singleton.SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }

    public void LeaveGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.Shutdown();
        }
        else
        {
            NetworkManager.Singleton.Shutdown();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }
}
