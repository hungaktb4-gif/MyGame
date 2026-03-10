using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    private int damage = 15;
    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    public Animator animator;
    private int numberOfKicks;
    private int attackRange = 2;
    public Transform attackPoint;
    private bool canKick = true;
    private float kickTime = 0f;
    private float nextKickTime = 0.1f;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K) && canKick)
        {
            numberOfKicks++;
            Attack();
            if(numberOfKicks >= 5)
            {
                StartCoroutine(WaitForKick());
            }
        }
    }
    public void Attack()
    {
        if(Time.time <= kickTime) return;
        animator.SetBool("isKick",true);
        Invoke("DoDamage",0.1f);
        kickTime = Time.time + nextKickTime;
    }


   public void DoDamage()
    {
        Collider2D[] hitsEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,LayerMask.GetMask("Enemy"));
        foreach(Collider2D enemies in hitsEnemies)
        {
            enemyHealth = enemies.GetComponent<EnemyHealth>();
            if(enemies != null)
            {
                enemyHealth.TakeDamage(damage);
                playerHealth.AddHealth(5);
            }
        }
        animator.SetBool("isKick",false);
    }
    IEnumerator WaitForKick()
    {
        canKick = false;
        numberOfKicks = 5;
        yield return new WaitForSeconds(3f);
        numberOfKicks = 0;
        canKick = true;
    }
    void OnDrawGizMosSellect()
    {
        if(attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
