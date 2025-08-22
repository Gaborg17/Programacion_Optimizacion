using UnityEngine;

public class Finalizar : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.Play("Juego");
        AudioManager.Instance.Stop("MenuInicio");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (GameManager.Instance.enemyDefeated >= 10)
            {
                Cursor.lockState = CursorLockMode.None;
                GameManager.Instance.ChangeScene("Creditos");
            }
        }

    }
}
