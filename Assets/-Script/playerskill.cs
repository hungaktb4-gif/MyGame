using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerskill : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    private float cooldown = 10f;
    private float nextCasttime = 0f;
    public Animator animator;
    private int damage = 100;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CastSkill();
        }   
    }
    void CastSkill()
    {
        if (Time.time <= nextCasttime)
          return;
        animator.SetTrigger("Skil1");
        Invoke("DoDamage", 0.5f);
        nextCasttime = Time.time + cooldown;
    }
    void DoDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, LayerMask.GetMask("Enemy"));
        foreach (Collider2D enemy in enemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
    void OnDrawGizMosSellect()
    {
        if(attackPoint == null)
         return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
