using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadItemDespawn();
    }
    protected virtual void LoadModel()
    {
        if(this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel",gameObject);
    }
    protected virtual void LoadItemDespawn()
    {
        if(this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn",gameObject);
    }
    
}
