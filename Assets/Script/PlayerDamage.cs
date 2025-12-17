using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private float nextDamageTime = 0f;
    public int damage = 25;
    public float damageInterVal = 1f;
    private bool isEnemyInrange = false;
    private float nextAttackTime = 0.2f;
    private EnemyHealth enemyHealth;
    private float attackRange = 1.5f;
    public Transform attackPoint;
    public float attackRate = 2f;
    public Animator animator;
    public Transform Enemy;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        if (Time.time <= nextDamageTime)
            return;
        animator.SetBool("isAttack",true);
        Invoke("DoDamage",0.5f);
        nextDamageTime = Time.time + nextAttackTime;
    }
     void DoDamage()
     {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
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