using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessEffects : MonoBehaviour
{
    private Volume vol;
    public Vignette vignette;
    public FilmGrain grain;
    void Start()
    {
        vol = GetComponent<Volume>();
        vol.profile.TryGet(out vignette);
        vol.profile.TryGet(out grain);
    }

}
