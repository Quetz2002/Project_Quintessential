using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIMessageManager : MonoBehaviour
{
    public static UIMessageManager instance;

    [SerializeField] private TMP_Text Message;

    private void Awake()
    {
        instance = this;
        Message.text = "";
    }

    private void ClearMessage()
    {
        Message.text = "";
    }

    public void ShowMessage(string message)
    {
        Message.text = message;
        CancelInvoke();
        Invoke("ClearMessage", 3f);
    }
}
