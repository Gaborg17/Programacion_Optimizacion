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

    [SerializeField]
    private Transform[] posMov;

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
        if (Vector3.Distance(transform.position, posMov[coord].position) < .4f)
        {

            coord++;
            if (coord >= posMov.Length)
            {
                coord = 0;
            }
        }
        if (detect)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(posMov[coord].position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Muerte");
            GameManager.Instance.enemyDefeated = 0;
            GameManager.Instance.ReiniciarDatos();
            GameManager.Instance.ChangeScene("ProyectoGameEngine");
            Debug.Log("Paaaa");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
