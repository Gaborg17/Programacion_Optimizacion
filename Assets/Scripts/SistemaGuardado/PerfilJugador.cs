using UnityEngine;


[System.Serializable]
public class PerfilJugador
{
    public float posX;
    public float posY;
    public float posZ;

    public int balas;

    public PerfilJugador()
    {
        posX = GameManager.Instance.posX;
        posY = GameManager.Instance.posY;
        posZ = GameManager.Instance.posZ;

        balas = GameManager.Instance.balas;
    }

}


