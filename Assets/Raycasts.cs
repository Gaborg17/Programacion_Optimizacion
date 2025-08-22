using UnityEngine;

public class Raycasts : MonoBehaviour
{
    [SerializeField]
    private float rango;

    private Transform shootPoint;
    private RaycastHit hit;

    [SerializeField]
    private LayerMask interactable;
    [SerializeField]
    private LayerMask enemyMask;




    private void Awake()
    {
        shootPoint = transform.parent;
    }

    void Update()
    {
        RaycastHit hit;


        if (Input.GetMouseButton(0) && GameManager.Instance.isGuninHand)
        {
            AudioManager.Instance.Play("DisparoGun");
        }
        else if (Input.GetMouseButton(0) && GameManager.Instance.isRifleinHand)
        {
            AudioManager.Instance.Play("DisparoRifle");
        }

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.isGuninHand)
        {
            Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 2, enemyMask);
            if (hit.transform != null)
            {

                if (hit.transform.CompareTag("Enemy"))
                {
                    AudioManager.Instance.Play("ImpactoDisparo");
                    Destroy(hit.transform.gameObject);
                    GameManager.Instance.enemyDefeated++;
                }
            }
        }

        else if(Input.GetMouseButton(0) && GameManager.Instance.isRifleinHand)
        {
            Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, 15, enemyMask);
            if (hit.transform != null)
            {

                if (hit.transform.CompareTag("Enemy"))
                {
                    AudioManager.Instance.Play("ImpactoDisparo");
                    Destroy(hit.transform.gameObject);
                    GameManager.Instance.enemyDefeated++;
                }
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rango);
    }
}
