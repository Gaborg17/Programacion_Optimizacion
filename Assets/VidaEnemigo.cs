using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField]
    int vida;

    public void Da�oEnemigo(int da�o)
    {
        vida -= da�o;
        if(vida <= 0)
        {
            
            Destroy(this.gameObject);
        }
    }

}
