using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    [Range(0, 1000)]
    public int amountToPool;
    public static ObjectPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        CreateObjectPool();

    }

    void CreateObjectPool()
    {
        //this method creates the pool of objects based of the amountToPool value then it makes it a child of the 
        //object pooler game object
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        //this method is used to retrieve a pooled object that is not currently active in the hierarchy
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {

                return pooledObjects[i];
            }
        }

        return null;
    }
}