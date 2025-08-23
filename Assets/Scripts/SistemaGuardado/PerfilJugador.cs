using UnityEngine;


[System.Serializable]
public class PerfilJugador
{
    public float posX;
    public float posY;
    public float posZ;

    public bool hasaGun;
    public bool hasRifle;


    public int balasGun;
    public int balasRifle;

    public int ammoInStockGun;
    public int ammoInStockRifle;

    public PerfilJugador()
    {
        if (GameManager.Instance != null)
        {
            posX = GameManager.Instance.posX;
            posY = GameManager.Instance.posY;
            posZ = GameManager.Instance.posZ;

            hasaGun = GameManager.Instance.hasaGun;
            hasRifle = GameManager.Instance.hasRifle;

            balasGun = GameManager.Instance.balasGun;
            balasRifle = GameManager.Instance.balasRifle;

            ammoInStockGun = GameManager.Instance.ammoInStockGun;
            ammoInStockRifle = GameManager.Instance.ammoInStockRifle;
        }
    }

}


