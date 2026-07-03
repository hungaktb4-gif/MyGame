using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KuroyamiSkill : HungMonoBehaviour
{
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected string dataName;
    [SerializeField] protected HeroData heroData;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float attackRange = 0.6f;
    [SerializeField] protected EnemyHealth enemyHealth;
    [SerializeField] protected int damage = 50;
    [SerializeField] protected int cooldown = 10;
    [SerializeField] protected float nextDamageTime = 0f;
    [SerializeField] protected bool canCastSkill;

    protected override void LoadComponents()
    {
        this.LoadAnimator();
        this.LoadSO();
    }
    protected virtual void LoadAnimator()
    {
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }
    protected virtual void LoadSO()
    {
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
