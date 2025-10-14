using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Object Pooling
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] private GameObject objectToSpawn;

    [SerializeField] private int poolSize;
    [SerializeField] private int maxObjectsInScene;
    [SerializeField] private int activeObjects;

    Queue<GameObject> pool;


    private void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0;i< poolSize; i++)
        {
            GameObject instance = Instantiate(objectToSpawn);
            instance.SetActive(false);
            pool.Enqueue(instance);
        }
    }


}
