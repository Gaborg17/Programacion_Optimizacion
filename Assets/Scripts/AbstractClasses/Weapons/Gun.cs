using System.Collections;
using UnityEngine;

public class Gun : Weapons
{
    public override void Shoot()
    {
        if (actualAmmo > 0 && canShoot && !reloading)
        {
            actualAmmo--;
            canShoot = false;
            StartCoroutine(CoolDown());
            AudioManager.Instance.Play("DisparoGun");

        }

        else if (actualAmmo <= 0 && ammoInStock > 0 && !reloading && canShoot)
        {
            Reload();
        }
    }

    public override void Reload()
    {
        StartCoroutine(Reloading());
    }

    public IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public IEnumerator Reloading()
    {
        if (ammoInStock > 0)
        {
            canShoot = false;
            reloading = true;
            for (int i = actualAmmo; actualAmmo != magSize; i++)
            {
                actualAmmo++;
                ammoInStock--;


                if (ammoInStock <= 0)
                {

                    break;
                }
            }
            yield return new WaitForSeconds(reloadSpeed);
            reloading = false;
            canShoot = true;
        }
    }
}
