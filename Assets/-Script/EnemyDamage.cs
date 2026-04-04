using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
   public EnemyData enemyData;
   public string dataName;
   public PlayerHealth playerHealth;
   private float attackRange = 1.5f;
   private Rigidbody2D rb;
   public Transform Player;
   private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyData = Resources.Load<EnemyData>(dataName);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            InvokeRepeating("UpdateAnimation",0f,0.1f);
            InvokeRepeating("DoDamage",0f, 0.5f);    
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth = null;
            UpdateAnimation();
            CancelInvoke("DoDamage");
        }      
    }
    void DoDamage()
    {
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(enemyData.damage);
        }
    }
    void UpdateAnimation()
    {
        float distance = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
        bool isAttack = distance <= attackRange;
        animator.SetBool("isAttack",isAttack);
        animator.SetBool("isRunning",!isAttack);
    }
}
