using UnityEngine;

public class Guardar : MonoBehaviour
{
    private PerfilJugador perfil;
    private GameObject player;
    private CharacterController ctrl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F4))
        {
            GameManager.Instance.GuardarDatos();
            SaveSystem.GuardarPartida();
        }
    }

}
