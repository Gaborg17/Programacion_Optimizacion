using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    public bool isGun;
    public bool isRifle;

    private void OnTriggerEnter(Collider other)
    {
        if(isGun == true)
        {
            GameManager.Instance.hasaGun = true;
            Destroy(this.gameObject);
        }
        else if(isRifle == true)
        {
            GameManager.Instance.hasRifle = true;
            Destroy(this.gameObject);
        }
    }

}
