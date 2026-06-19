using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DamageReceiver : SaiMonoBehaviour
{
    // Script này dùng để quản lý máu(nhận sát thương hoặc trừ sát thương)
    [SerializeField] protected int maxHp = 1;
    [SerializeField] protected int Hp;
    [SerializeField] protected SphereCollider sphereCollider;
    protected bool isDead;

    protected override void OnEnable()
    {
        this.Reborn();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.25f;
        Debug.Log(transform.name + ": LoadSphereCollider",gameObject);
    }
    public virtual void Reborn()
    {
        this.Hp = this.maxHp;
        this.isDead = false;
    }
    public virtual void Add(int add)
    {
        if(this.isDead) return;
        this.Hp += add;
        if(this.Hp > maxHp) Hp = maxHp;
    }
    public virtual void Deduct(int deduct)
    {
        if(this.isDead) return;
        this.Hp -= deduct;
        if(this.Hp <= 0 ) this.Hp = 0;    
        this.CheckDead();
    }
    public virtual bool IsDead()
    {
        return this.Hp <= 0;
    }
    protected virtual void CheckDead()
    {
        if(!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    protected virtual void OnDead()
    {
        // this function for override
    }
}
