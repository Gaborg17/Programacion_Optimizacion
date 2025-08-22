using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]
    private int dañoBala;

    private bool check = false;
    private GameObject collObj;

    private void Update()
    {
        if (check)
        {
            collObj.GetComponent<VidaEnemigo>().DañoEnemigo(50);
            check = false;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collObj = collision.gameObject;
            check = true;
            
        }

        
    }

}
