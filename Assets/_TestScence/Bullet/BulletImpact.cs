using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(SphereCollider))]
 [RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("BulletImpact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ": LoadSphereCollder",gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.isKinematic = true;
        Debug.Log(transform.name + ": LoadRigidbody",gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        this.bulletCtrl.DamageSender.Send(other.transform);
        Debug.Log(transform.name + "Va chạm với 🚀🚀🚀" +other.name);
    }
}
