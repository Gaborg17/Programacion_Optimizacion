using UnityEngine;

public class Guardar : MonoBehaviour
{
    private PerfilJugador perfil;
    private GameObject player;
    private CharacterController ctrl;

    [SerializeField]
    private bool canSave;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && canSave)
        {
            GameManager.Instance.GuardarDatos();
            SaveSystem.GuardarPartida();
            Debug.Log("Guardando");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSave = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSave = false;

        }
    }

}
