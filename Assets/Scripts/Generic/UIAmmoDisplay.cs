using TMPro;
using UnityEngine;

public class UIAmmoDisplay : MonoBehaviour
{
    public WeaponsHandler wHandler;

    public TextMeshProUGUI ammoDisplay;
    public int actualAmmo;
    public int stockAmmo;

    void Start()
    {
        wHandler = FindAnyObjectByType<WeaponsHandler>();
    }

    void Update()
    {
        actualAmmo = wHandler.weaponInHand.actualAmmo;
        stockAmmo = wHandler.weaponInHand.ammoInStock;

        ammoDisplay.text = $"{actualAmmo} / {stockAmmo}";
    }
}
