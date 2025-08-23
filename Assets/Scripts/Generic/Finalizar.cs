using UnityEngine;

public class Finalizar : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play("Juego");
        AudioManager.Instance.Stop("MenuInicio");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.Instance.ChangeScene("Inicio");
            Cursor.lockState = CursorLockMode.None;
            GameManager.Instance.ReiniciarDatos();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (GameManager.Instance.enemyDefeated >= 10)
            {
                Cursor.lockState = CursorLockMode.None;
                GameManager.Instance.ReiniciarDatos();
                GameManager.Instance.ChangeScene("Creditos");
            }
        }

    }
}
