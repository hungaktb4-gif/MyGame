using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuroyamiAttack : HungMonoBehaviour
{
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected string dataName;
    [SerializeField] protected HeroData heroData;
    [SerializeField] protected int damage = 10;
    protected float attackRange = 0.6f;
    protected Animator animator;
    protected int numberOfAttack = 0;
    protected EnemyHealth enemyHealth;
    protected bool isClick;

    protected override void LoadComponents()
    {
        this.animator = GetComponent<Animator>();
        this.heroData = Resources.Load<HeroData>(dataName);
        this.heroData.damageAttack = damage;
    }
    // Update is called once per frame
    void Update()
    {
        this.GetMouseDown();
    }
    protected virtual void GetMouseDown()
    {
        if(!this.IsClicking()) return;
        this.numberOfAttack++;
        this.Attack();
    }
    protected virtual bool IsClicking()
    {
        this.isClick = NewInputManager.Instance.onClick; 
        return isClick;  
    }
    protected override void Attack()
    {
        if(numberOfAttack % 2 == 0)
        {
            this.animator.SetTrigger("slashHorizontal");
            this.numberOfAttack = 0;
        }
        else
        {
            this.animator.SetTrigger("slashVertical");
        }
        Invoke(nameof(CheckEnemies),0.1f);
    }
    protected virtual void CheckEnemies()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, LayerMask.GetMask("Enemy"));
        this.AttackEnemies(enemies);
    }
    protected virtual void AttackEnemies(Collider2D[] enemies)
    {
        foreach(Collider2D enemy in enemies)
        {
            this.enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                this.enemyHealth.TakeDamage(heroData.damageAttack);
            }
        }
    }
}
