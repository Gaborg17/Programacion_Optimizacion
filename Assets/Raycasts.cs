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


    public Transform player;
    public WeaponsHandler wHandler;

    private void Awake()
    {
        shootPoint = transform.parent;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wHandler = player.GetComponent<WeaponsHandler>();
    }

    void Update()
    {

        rango = wHandler.weaponInHand.range;
        if (wHandler.ShotType == wHandler.OneShot && wHandler.weaponInHand.canShoot && wHandler.weaponInHand.actualAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RayShot();
            }
        }
        else if (wHandler.ShotType == wHandler.AutomaticShot && wHandler.weaponInHand.canShoot && wHandler.weaponInHand.actualAmmo > 0)
        {
            if (Input.GetMouseButton(0))
            {
                RayShot();
            }
        }


    }

    private void RayShot()
    {
        RaycastHit hit;

        Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, wHandler.weaponInHand.range, enemyMask);
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * rango);
    }
}
