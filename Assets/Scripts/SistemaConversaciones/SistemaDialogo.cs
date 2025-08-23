using UnityEngine;

[System.Serializable]
public class SistemaDialogo
{
    public string nombre;

    [TextArea (3,5)]
    public string textoDialogo;

    public Sprite personaje1;
    public Sprite personaje2;

    public Sprite box;
}
