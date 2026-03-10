using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerskill : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    private float cooldown = 10f;
    private float nextCasttime = 0f;
    private Animator animator;
    private int damage = 25;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastSkill();
        }   
    }
    public void CastSkill()
    {
        if (Time.time <= nextCasttime)
          return;
        animator.SetBool("castSkill",true);
        Invoke("DoDamage", 0.5f);
        nextCasttime = Time.time + cooldown;
    }
    public void DoDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, LayerMask.GetMask("Enemy"));
        if(enemies.Length == 0)
        {
            playerHealth.AddHealth(4);
        }
        foreach (Collider2D enemy in enemies)
        {
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                playerHealth.AddHealth(8);
            }
        }
        animator.SetBool("castSkill",false);
    }
    void OnDrawGizMosSellected()
    {
        if(attackPoint == null)
         return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
