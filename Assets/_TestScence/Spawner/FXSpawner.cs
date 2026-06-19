using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance; //singleton
    public static FXSpawner Instance => instance; //singleton
    public static string smoke1 = "Smoke_1";

    protected override void Awake()
    {
        base.Awake();
        if(FXSpawner.instance != null) Debug.LogError("Only 1 FXSpanwer allowed to exist");
        FXSpawner.instance = this;
    }
}
