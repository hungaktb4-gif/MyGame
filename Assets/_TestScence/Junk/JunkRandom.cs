using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : SaiMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpanwerCtrl();
    }

    protected virtual void LoadJunkSpanwerCtrl()
    {
        if(this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkSpawnerCtrl",gameObject);

    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne,pos,rot);
        obj.gameObject.SetActive(true);
        Invoke(nameof(JunkSpawning),1f);
    }
}
