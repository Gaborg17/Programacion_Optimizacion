using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Conversacion : MonoBehaviour
{
    [SerializeField] private string[] frases;  // Frases del diálogo
    [SerializeField] private float rango = 3f; // Rango de interacción
    [SerializeField] private LayerMask capaJugador;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TextMeshProUGUI textoDialogo;

    private bool jugadorCerca;
    private int lineaActual = 0;

    void Update()
    {
        jugadorCerca = Physics.CheckSphere(transform.position, rango, capaJugador);

        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (lineaActual < frases.Length)
            {
                MostrarDialogo();
                lineaActual++;
            }
            else
            {
                TerminarDialogo();
            }
        }
    }

    void MostrarDialogo()
    {
        panelDialogo.SetActive(true);
        textoDialogo.text = frases[lineaActual];
        AudioManager.Instance.Play("Dialogo");
    }

    void TerminarDialogo()
    {
        AudioManager.Instance.Stop("Dialogo");
        panelDialogo.SetActive(false);
        lineaActual = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
