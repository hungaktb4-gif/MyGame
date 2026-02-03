using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemhealthPool : MonoBehaviour
{
    private Queue<GameObject> pool;
    private int poolSize = 5;
    public GameObject pillPrefab; 
    // Start is called before the first frame update
    private void Awake()
    {
        pool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pillPrefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }
    public GameObject GetObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(pillPrefab);
            obj.SetActive(true);
            return obj;
        }
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
