using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : PlayerBase
{
    private float nextDamageTime = 0f;
    public int damage = 10;
    public string dataName;
    public HeroData heroData;
    private float nextAttackTime = 0.4f;
    private EnemyHealth enemyHealth;
    private float attackRange = 1.5f;
    public Transform attackPoint;
    public Animator animator;
    public Transform Enemy;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        heroData = Resources.Load<HeroData>(dataName);
    }
    void Start()
    {
        heroData.damageAttack = damage;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    protected override void Attack()
    {
        if (Time.time <= nextDamageTime)
            return;
        animator.SetBool("isAttack",true);
        Invoke("DoDamage",0.1f);
        nextDamageTime = Time.time + nextAttackTime;
    }
     void DoDamage()
     {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(heroData.damageAttack);
        }
        animator.SetBool("isAttack",false);
     }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
           return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}