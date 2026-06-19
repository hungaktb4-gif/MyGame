using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    protected static BulletSpawner instance; //singleton
    public static BulletSpawner Instance => instance; //singleton
    public static string bulletOne = "Bullet_1";
    public static string bulletTwo = "Bullet_2";

    protected override void Awake()
    {
        base.Awake();
        if(BulletSpawner.instance != null) Debug.LogError("Only 1 instance bullet spawner allow");
        BulletSpawner.instance = this;  
    }
}
