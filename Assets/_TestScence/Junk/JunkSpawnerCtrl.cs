using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkSpawnerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    [SerializeField] protected JunkSpawnPoint spawnPoint;
    public JunkSpawner JunkSpawner => junkSpawner;
    public JunkSpawnPoint SpawnPoint => spawnPoint; 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadJunkSpawner()
    {
        if(this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner",gameObject);
    }
    protected virtual void LoadSpawnPoints()
    {
        if(this.spawnPoint != null) return;
        this.spawnPoint = Transform.FindObjectOfType<JunkSpawnPoint>();
        Debug.Log(transform.name + ": LoadSpawnPoint");
    }
}
