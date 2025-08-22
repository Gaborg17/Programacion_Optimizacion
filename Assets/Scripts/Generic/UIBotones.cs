using UnityEngine;

public class UIBotones : MonoBehaviour
{
    public void IniciarJuego()
    {
        GameManager.Instance.ChangeScene("ProyectoGameEngine");
    }

    public void IrACreditos()
    {
        GameManager.Instance.ChangeScene("Creditos");
    }

    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del Juego...");
    }

    public void VolverAlMenu()
    {
        GameManager.Instance.ChangeScene("Inicio");
    }
}
