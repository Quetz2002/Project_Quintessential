using UnityEngine;
using UnityEngine.SceneManagement; // Requisito indispensable para cambiar de escena

public class CambioEscena : MonoBehaviour
{
    // Método para cargar por nombre de escena
    public void CambiarASena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Método para salir del juego
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo..."); // Solo se ve en el editor
        Application.Quit();
    }
}