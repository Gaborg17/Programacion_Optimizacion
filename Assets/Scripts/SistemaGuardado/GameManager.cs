using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public int enemyDefeated;

    public bool hasaGun;
    public bool hasRifle;


    public int balasGun;
    public int balasRifle;

    public int ammoInStockGun;
    public int ammoInStockRifle;

    public WeaponsHandler wHandler;

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
        wHandler = player.GetComponent<WeaponsHandler>();
        posX = player.position.x;
        posY = player.position.y;
        posZ = player.position.z;


        balasGun = wHandler.weapons[0].actualAmmo;
        balasRifle = wHandler.weapons[1].actualAmmo;

        ammoInStockGun = wHandler.weapons[0].ammoInStock;
        ammoInStockRifle = wHandler.weapons[1].ammoInStock;

        hasaGun = hasaGun;
        hasRifle = hasRifle;
    }

    public void ReiniciarDatos()
    {
        posX = 0;
        posY = 0;
        posZ = 0;
        hasaGun = false;
        hasRifle = false;
        balasGun = 0;
        balasRifle=0;
        ammoInStockGun=0;
        ammoInStockRifle=0;
        enemyDefeated = 0;
    }

    public void ChangeScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public IEnumerator Mover()
    {
        yield return new WaitForSeconds(.1f);
        Debug.Log("SeMovio");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CharacterController ctrl = player.GetComponent<CharacterController>();
        ctrl.enabled = false;
        player.transform.position = new Vector3(posX, posY, posZ);
        ctrl.enabled = true;
        yield return new WaitForSeconds(.1f);
        WeaponsHandler wHandler = player.GetComponent<WeaponsHandler>();
        wHandler.weapons[0].actualAmmo = balasGun;
        wHandler.weapons[1].actualAmmo = balasRifle;
        wHandler.weapons[0].ammoInStock = ammoInStockGun;
        wHandler.weapons[1].ammoInStock = ammoInStockRifle;
    }



}
