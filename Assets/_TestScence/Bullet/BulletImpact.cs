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
        this.sphereCollider.radius = 0.04f;
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
        if(other.transform.parent == this.bulletCtrl.Shooter) return;
        this.CreatImpactFX();
        this.bulletCtrl.DamageSender.Send(other.transform);   
    }
    protected virtual void CreatImpactFX()
    {
        string fxName = this.GetImpactFXName();
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Quaternion rotationEffect = Quaternion.Euler(0,0,-90);
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName,hitPos, hitRot*rotationEffect);
        fxImpact.gameObject.SetActive(true);
    }
    protected string GetImpactFXName()
    {
        return FXSpawner.impact1;
    }
}
