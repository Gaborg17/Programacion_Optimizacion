using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarDatos : MonoBehaviour
{
    private PerfilJugador perfil;

    public void InicioJuego(string nombreGuardado)
    {
        GameManager.Instance.nombreGuardado = nombreGuardado;

        perfil = SaveSystem.CargarPartida();

        if (perfil != null)
        {
            GameManager.Instance.posX = perfil.posX;
            GameManager.Instance.posY = perfil.posY;
            GameManager.Instance.posZ = perfil.posZ;

            GameManager.Instance.hasaGun = perfil.hasaGun;
            GameManager.Instance.hasRifle = perfil.hasRifle;

            GameManager.Instance.balasGun = perfil.balasGun;
            GameManager.Instance.balasRifle = perfil.balasRifle;

            GameManager.Instance.ammoInStockGun = perfil.ammoInStockGun;
            GameManager.Instance.ammoInStockRifle = perfil.ammoInStockRifle;
            SceneManager.LoadScene("ProyectoGameEngine");
            GameManager.Instance.StartCoroutine(GameManager.Instance.Mover());
            Debug.Log("Cargo");

        }
        else
        {
            SceneManager.LoadScene("ProyectoGameEngine");
        }

    }

}
