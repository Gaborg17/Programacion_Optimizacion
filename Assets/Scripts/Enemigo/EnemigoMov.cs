using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoMov : MonoBehaviour
{
    private Vector3 iniPos;


    private NavMeshAgent agent;

    private Transform player;

    private bool detect;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask mask;



    public int coord = 0;

    private void Start()
    {
        iniPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        detect = Physics.CheckSphere(transform.position, radius, mask);
        if (detect)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(iniPos);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GameManager.Instance.enemyDefeated = 0;
            GameManager.Instance.ChangeScene("PrograOpt");
            Debug.Log("Paaaa");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
