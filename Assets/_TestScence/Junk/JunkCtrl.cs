using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkCtrl : SaiMonoBehaviour
{
    protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
    }
    protected virtual void LoadJunkSpawner()
    {
        if(this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": LoadJunkSpawner",gameObject);
    }
}
