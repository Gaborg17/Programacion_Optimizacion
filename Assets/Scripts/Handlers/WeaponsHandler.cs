using System;
using UnityEngine;

public class WeaponsHandler : MonoBehaviour
{
    public Weapons weaponInHand;

    public Weapons[] weapons = new Weapons[2];

    public int actualWeaponIndex;

    public Action ShotType;

    void Start()
    {
        weaponInHand = weapons[actualWeaponIndex];
        SwitchShootInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.hasaGun || GameManager.Instance.hasRifle)
        {
            weaponInHand.transform.GetChild(0).gameObject.SetActive(true);
            if (GameManager.Instance.hasaGun && GameManager.Instance.hasRifle)
            {

                SwitchWeapon();
            }
            ShotType();
            Reloading();
        }

    }

    public void AutomaticShot()
    {
        if (Input.GetMouseButton(0))
        {
            weaponInHand.Shoot();
        }
    }

    public void OneShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weaponInHand.Shoot();
        }
    }

    private void SwitchWeapon()
    {
        if (Input.mouseScrollDelta.y == 0)
        {
            weaponInHand.transform.GetChild(0).gameObject.SetActive(true);
            return;
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            weaponInHand.transform.GetChild(0).gameObject.SetActive(false);
            actualWeaponIndex = actualWeaponIndex + 1 >= weapons.Length ? 0 : actualWeaponIndex + 1;
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            weaponInHand.transform.GetChild(0).gameObject.SetActive(false);
            actualWeaponIndex = actualWeaponIndex - 1 < 0 ? weapons.Length - 1 : actualWeaponIndex - 1;

        }

        weaponInHand = weapons[actualWeaponIndex];
        SwitchShootInput();
    }

    private void SwitchShootInput()
    {
        switch (weaponInHand)
        {
            case Rifle: ShotType = AutomaticShot; Debug.Log("Disparo actual: Automatico"); break;

            case Gun: ShotType = OneShot; Debug.Log("Disparo actual: Regular"); break;

        }
    }

    private void Reloading()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weaponInHand.Reload();
        }
    }


}
