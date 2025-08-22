using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemyDefeated;

    public bool hasaGun;

    public bool hasRifle;

    public bool isRifleinHand;
    public bool isGuninHand;

    public int balas;

    [Header("Posicion Player")]
    public float posX;
    public float posY;
    public float posZ;
    private Transform player;

    public string nombreGuardado;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GuardarDatos()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        posX = player.position.x;
        posY = player.position.y;
        posZ = player.position.z;
    }


    public void ChangeScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }



}
