using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessEffects : MonoBehaviour
{
    private Volume vol;
    public ColorAdjustments colorAdjustments;
    void Start()
    {
        vol = GetComponent<Volume>();
        vol.profile.TryGet(out colorAdjustments);
    }

}
