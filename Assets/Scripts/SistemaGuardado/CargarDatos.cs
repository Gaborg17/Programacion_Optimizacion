using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarDatos : MonoBehaviour
{
    private PerfilJugador perfil;

    public void InicioJuego(string nombreGuardado)
    {
        GameManager.Instance.nombreGuardado = nombreGuardado;

        perfil = SaveSystem.CargarPartida();

        if (perfil == null)
        {
            GameManager.Instance.posX = perfil.posX;
            GameManager.Instance.posY = perfil.posY;
            GameManager.Instance.posZ = perfil.posZ;
        }
        else
        {
            SceneManager.LoadScene("");
        }

        //player = GameObject.FindGameObjectWithTag("Player");
        //ctrl = player.GetComponent<CharacterController>();
        //ctrl.enabled = false;
        //player.transform.position = new Vector3(GameManager.Instance.transform);
        //ctrl.enabled = true;
    }

}
