using UnityEngine;

public class AmmoCollector : MonoBehaviour
{
    public int ammoToAdd;

    public bool gunAmmo;
    public bool rifleAmmo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponsHandler wHandler = other.GetComponent<WeaponsHandler>();
            
            if (gunAmmo)
            {
                wHandler.weapons[0].ammoInStock += ammoToAdd;
                Destroy(this.gameObject);
            }
            else if (rifleAmmo)
            {
                wHandler.weapons[1].ammoInStock += ammoToAdd;
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("No es necesario");
            }
        }
    }

}
