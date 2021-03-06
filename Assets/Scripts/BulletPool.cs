using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;

        for(int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public BulletControl GetPoolBullet()
    {
        for(int i=0;i<amountToPool;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i].GetComponent<BulletControl>();
            }
        }
        return null;
    }
}