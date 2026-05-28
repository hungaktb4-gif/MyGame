using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KuroyamiSkill : HungMonoBehaviour
{
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected string dataName;
    [SerializeField] protected HeroData heroData;
    protected float attackRange = 0.6f;
    protected Animator animator;
    protected EnemyHealth enemyHealth;
    protected int damage = 50;
    protected int cooldown = 10;
    protected bool canCastSkill;
    protected float nextDamageTime = 0f;

    protected override void LoadComponents()
    {
        this.animator = GetComponent<Animator>();
        this.heroData = Resources.Load<HeroData>(dataName);
        this.heroData.damageSkill = damage;
    }
    void Update()
    {
        this.CastSkill();
    }
    protected virtual void CastSkill()
    {
        if(!this.IsCastSkill()) return;
        this.Attack();
    }
    protected virtual bool IsCastSkill()
    {
        this.canCastSkill = NewInputManager.Instance.GetKeyButtonDown(KeyCode.Q);
        return canCastSkill;
    }
    protected override void Attack()
    {
        if(Time.time <= nextDamageTime) return;
        this.animator.SetTrigger("castSkill");
        Invoke("CheckEnemies",0.3f);
        nextDamageTime = Time.time + cooldown;
    }
    protected virtual void CheckEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,LayerMask.GetMask("Enemy"));
        this.AttackEnemies(enemies);
    }
    protected virtual void AttackEnemies(Collider2D[] enemies)
    {
        foreach(Collider2D enemy in enemies)
        {
            this.GetDamage(enemy); 
        }
    }
    protected virtual void GetDamage(Collider2D enemy)
    {
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(heroData.damageSkill);
        }
    }
}
