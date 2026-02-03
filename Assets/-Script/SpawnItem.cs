using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public ItemhealthPool itempool;
     void Start()
    {
        SpawnHealthItem();
    }
    public void SpawnHealthItem()
    {
        float RandomX = Random.Range(-4,4);
        float Y = 0f;
        Vector3 spawnPos = new Vector3(RandomX,Y,0);
        GameObject pill = itempool.GetObject();
        pill.transform.position = spawnPos;
    }
}
