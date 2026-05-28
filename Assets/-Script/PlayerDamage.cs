using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : HungMonoBehaviour
{
    [SerializeField] protected float nextDamageTime = 0f;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected Animator animator;
    [SerializeField] protected HeroData heroData;
    [SerializeField] protected string dataName;
    protected bool isClicking;
    protected float nextAttackTime = 0.4f;
    protected EnemyHealth enemyHealth;
    protected float attackRange = 1.5f;
    // Start is called before the first frame update
    protected override void LoadComponents()
    {
        animator = GetComponent<Animator>();
        heroData = Resources.Load<HeroData>(dataName);
    }
    void Update()
    {
        this.GetMouseDown();
    }
    protected virtual void GetMouseDown()
    {
        if(!this.IsClicking()) return;
        this.Attack();
    }
    protected virtual bool IsClicking()
    {
        this.isClicking = NewInputManager.Instance.onClick;
        return this.isClicking;
    }
    protected override void Attack()
    {
        if (Time.time <= nextDamageTime) return;
        animator.SetBool("isAttack",true);
        Invoke("CheckEnemies",0.1f);
        nextDamageTime = Time.time + nextAttackTime;
    }
     protected virtual void CheckEnemies()
     {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));
        this.AttackEnemy(hitEnemies);
     }
    protected virtual void AttackEnemy(Collider2D[] hitEnemies)
    {
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(heroData.damageAttack);
        }
        animator.SetBool("isAttack",false);
    }
    void OnDrawGizmosSelected()
    {
        if (this.attackPoint == null)
           return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}