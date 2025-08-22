using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public int actualAmmo;
    public int ammoInStock;

    public int magSize;
    public int maxAmmo;

    public float reloadSpeed;
    //public int damage;
    public float range;
    public float fireRate;

    public bool canShoot;
    public bool reloading;

    // Update is called once per frame
    public void Update()
    {
        
    }

    public abstract void Shoot();
    public abstract void Reload();

}
