using System.Linq;
using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    public bool isGun;
    public bool isRifle;

    public GameObject displayAmmo;

    private void OnTriggerEnter(Collider other)
    {
        if(isGun == true)
        {
            displayAmmo.SetActive(true);
            GameManager.Instance.hasaGun = true;
            Destroy(this.gameObject);
        }
        else if(isRifle == true)
        {
            displayAmmo.SetActive(true);
            GameManager.Instance.hasRifle = true;
            Destroy(this.gameObject);
        }
    }

}
