using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;
using UnityEngine.SceneManagement;

public class LobbyManager : NetworkBehaviour
{
    public Button hostButton;
    public Button clientButton;
    public Button startGameButton;
    public TMP_Text playerText;

    private void Start()
    {
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
        startGameButton.onClick.AddListener(StartGame);
        
        
            startGameButton.gameObject.SetActive(false);
        
    }

    void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        hostButton.gameObject.SetActive(false);
        clientButton.gameObject.SetActive(false);
    }

    void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        hostButton.gameObject.SetActive(false);
        clientButton.gameObject.SetActive(false);
    }

    void StartGame()
    {
        if (!IsHost) return;

        //SceneManager.LoadScene("SampleScene");
        NetworkManager.Singleton.SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            NetworkManager.Singleton.OnClientConnectedCallback += UpdatePlayerCount;
            NetworkManager.Singleton.OnClientDisconnectCallback += UpdatePlayerCount;

            UpdatePlayerCount(0);
        }
    }

    private void OnEnable()
    {
        if (NetworkManager.Singleton != null && NetworkManager.Singleton.IsServer)
        {
            int count = NetworkManager.Singleton.ConnectedClients.Count;
            UpdatePlayerCountClientRpc(count);
        }

        NetworkManager.Singleton.SceneManager.OnLoadComplete += OnSceneLoaded;
    }

    void UpdatePlayerCount(ulong clientID)
    {
        if (!IsServer) return;

        int count = NetworkManager.Singleton.ConnectedClients.Count;
        UpdatePlayerCountClientRpc(count);
    }

    [ClientRpc]
    void UpdatePlayerCountClientRpc(int count)
    {
        playerText.text = "Jugadores Conectados: " + count;
        startGameButton.gameObject.SetActive(IsHost);
        hostButton.gameObject.SetActive(true);
        clientButton.gameObject.SetActive(true);
    }

    private void OnSceneLoaded(ulong clientID, string sceneName, LoadSceneMode mode)
    {
        if (sceneName == "SampleScene")
        {
            UpdatePlayerCount(0);
        }
    }
}
