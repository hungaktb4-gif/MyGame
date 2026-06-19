using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunkCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected JunkDespawn junkDespawn;
    [SerializeField] protected JunkSO junkSO;
    public JunkDespawn JunkDespawn => junkDespawn;
    public Transform Model => model;
    public JunkSO JunkSO => junkSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkDespawn();
        this.LoadModel();
        this.LoadJunkSO();
    }
    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel",gameObject);
    }
    protected virtual void LoadJunkDespawn()
    {
        if(this.junkDespawn != null) return;
        this.junkDespawn = GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ": LoadJunkDespawn",gameObject);
    }
    protected virtual void LoadJunkSO()
    {
        string respath = "Junk/" + transform.name;
        this.junkSO = Resources.Load<JunkSO>(respath);
    }
}
