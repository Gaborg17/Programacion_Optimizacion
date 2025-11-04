using UnityEngine;

public class Raycasts : MonoBehaviour
{
    [SerializeField]
    private float rango;

    public Transform shootPoint;
    private RaycastHit hit;

    [SerializeField]
    private LayerMask interactable;
    [SerializeField]
    private LayerMask enemyMask;


    public Transform player;
    public WeaponsHandler wHandler;

    private void Awake()
    {
        shootPoint = transform;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        wHandler = player.GetComponent<WeaponsHandler>();
    }

    void Update()
    {

        if (wHandler.ShotType == wHandler.OneShot && wHandler.weaponInHand.actualAmmo > 0)
        {
            Debug.Log("Debe funcionar");
            
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

        Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, wHandler.weaponInHand.range, enemyMask);


        if (hit.transform != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.CompareTag("Enemy"))
            {
                GameManager.Instance.enemyDefeated++;

                Spawn spawn = FindAnyObjectByType<Spawn>();
                spawn.BackToQueue(hit.transform.gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(shootPoint.position, shootPoint.forward * wHandler.weaponInHand.range);
    }
}
