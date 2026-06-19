using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class JunkSpawner : Spawner
{
    protected static JunkSpawner instance;
    public static JunkSpawner Instance => instance;
    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        if(JunkSpawner.instance != null) Debug.LogError("Only 1 JunkSpawner to exits");
        JunkSpawner.instance = this;
    }
}
