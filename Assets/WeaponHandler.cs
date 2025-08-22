using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject rifle;

    private int slot;



    [SerializeField]
    private GameObject weaponInHand;

    private void Update()
    {
        if (!GameManager.Instance.hasaGun)
        {
            GameManager.Instance.isGuninHand = false;
            GameManager.Instance.isRifleinHand = false;
            return;
        }
        
        else if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hasaGun)
        {
            slot = 1;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2)&& GameManager.Instance.hasRifle)
        {
            slot = 2;
        }

        switch (slot)
        {
            case 1:
                GameManager.Instance.isGuninHand = true;
                GameManager.Instance.isRifleinHand = false;
                rifle.SetActive(false); 
                gun.SetActive(true);
                weaponInHand = gun;
                break;
            case 2:
                GameManager.Instance.isGuninHand = false;
                GameManager.Instance.isRifleinHand = true;
                gun.SetActive(false);
                rifle.SetActive(true);
                weaponInHand = rifle;
                break;
        }

        
    }
}
