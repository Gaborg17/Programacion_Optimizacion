using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Rendering;

public class Conversacion : MonoBehaviour
{
    [SerializeField] private string[] frases;  // Frases del diálogo
    [SerializeField] private float rango = 3f; // Rango de interacción
    [SerializeField] private LayerMask capaJugador;
    [SerializeField] private GameObject panelDialogo;
    [SerializeField] private TextMeshProUGUI textoDialogo;

    public Volume gVolume;

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
        //ModificarPostProcess();
        panelDialogo.SetActive(true);
        textoDialogo.text = frases[lineaActual];
        AudioManager.Instance.Play("Dialogo");
    }

    void TerminarDialogo()
    {
        //ReiniciarPostProcess();
        AudioManager.Instance.Stop("Dialogo");
        panelDialogo.SetActive(false);
        lineaActual = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    //public void ModificarPostProcess()
    //{
    //    PostProcessEffects effects = FindAnyObjectByType<PostProcessEffects>();
    //    effects.vignette.intensity.value = .3f;
    //    effects.grain.intensity.value = 1;
    //}

    //public void ReiniciarPostProcess()
    //{
    //    PostProcessEffects effects = FindAnyObjectByType<PostProcessEffects>();
    //    effects.vignette.intensity.value = 0;
    //    effects.grain.intensity.value = 0;
    //}
}
