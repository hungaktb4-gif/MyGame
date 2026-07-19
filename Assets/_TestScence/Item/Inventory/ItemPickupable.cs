using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : JunkAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }
    public virtual ItemCode String2Enum(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }
    public virtual void OnMouseDown()
    {
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }
    protected virtual void LoadTrigger()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.05f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ":LoadTrigger ",gameObject);
    }
    public virtual ItemCode GetItemCode()
    {
        return String2Enum(transform.parent.name);
    }
    public virtual void Picked()
    {
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
}
