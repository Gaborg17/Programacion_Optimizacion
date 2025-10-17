using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    //Object Pooling
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform parentOfObjects;

    [SerializeField] private float spawnRate;

    [SerializeField] private int poolSize;
    [SerializeField] private int maxObjectsInScene;
    [SerializeField] private int activeObjects;

    Queue<GameObject> pool;

    
    private void Start()
    {
        pool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject instance = Instantiate(objectToSpawn);
            instance.transform.SetParent(parentOfObjects);
            instance.SetActive(false);
            pool.Enqueue(instance);
        }

        StartCoroutine(Spawns());
    }


    private IEnumerator Spawns()
    {
        for (int i = activeObjects; activeObjects < maxObjectsInScene; i++)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject objeto = pool.Dequeue();
            objeto.transform.position = GetRandomPos().position;
            objeto.SetActive(true);
            activeObjects++;
            StartCoroutine(BackToQueue(objeto));
        }
    }

    private IEnumerator BackToQueue(GameObject obj)
    {
        yield return new WaitForSeconds(.25f);
        obj.SetActive(false);
        pool.Enqueue(obj);
        activeObjects--;
    }


    private Transform GetRandomPos()
    {
        int randomSpawn = Random.Range(0, spawnPoints.Length);

        return spawnPoints[randomSpawn];
    }

}
