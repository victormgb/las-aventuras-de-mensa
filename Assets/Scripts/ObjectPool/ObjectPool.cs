using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> instancedObjects;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        instancedObjects = new List<GameObject>();

        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
            }
        }
    }

    public GameObject GetPoolObject(string tag)
    {
        for (int i = 0; i < instancedObjects.Count; i++)
        {
            if (!instancedObjects[i].activeInHierarchy && instancedObjects[i].CompareTag(tag))
            {
                return instancedObjects[i];
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.CompareTag(tag))
            {
                GameObject go = Instantiate(item.objectToPool);
                go.SetActive(false);
                instancedObjects.Add(go);
                return go;
            }
        }

        return null;
    }
}
