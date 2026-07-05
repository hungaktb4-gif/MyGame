using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class ItemLooter : SaiMonoBehaviour
{
   [SerializeField] protected Rigidbody _rigidbody;
   [SerializeField] protected SphereCollider sphereCollider;
   [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigidbody();
        this.LoadInventory();
    }
    protected virtual void LoadTrigger()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.3f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ":LoadSphereCollider: ",gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ":LoadRigidBody ",gameObject);
    }
    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.Log(transform.name+ ":LoadInventory ", gameObject);        
    }
    protected void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if(itemPickupable == null) return;
        ItemCode itemCode = itemPickupable.GetItemCode();
        if(this.inventory.AddItem(itemCode,1)) itemPickupable.Picked();
    }
}
