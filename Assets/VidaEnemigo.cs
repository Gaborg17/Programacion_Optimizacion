using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField]
    int vida;

    public void DañoEnemigo(int daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            
            Destroy(this.gameObject);
        }
    }

}
