using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : HungMonoBehaviour
{
   [SerializeField] protected EnemyData enemyData;
   [SerializeField] protected string dataName;
   [SerializeField] protected Transform Player;
   protected PlayerHealth playerHealth;
   protected float attackRange = 1.5f;
   protected Rigidbody2D rb;
   protected Animator animator;

    protected override void LoadComponents()
    {
        this.animator = GetComponent<Animator>();
        this.rb = GetComponent<Rigidbody2D>();
        this.enemyData = Resources.Load<EnemyData>(dataName);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            InvokeRepeating(nameof(UpdateAnimation),0f,0.1f);
            InvokeRepeating(nameof(DoDamage),0f, 0.5f);    
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            this.playerHealth = null;
            UpdateAnimation();
            CancelInvoke("DoDamage");
        }      
    }
    void DoDamage()
    {
        if(this.playerHealth != null)
        {
            this.playerHealth.TakeDamage(enemyData.damage);
        }
    }
    void UpdateAnimation()
    {
        float distance = Vector2.Distance(transform.position, PlayerController.Instance.transform.position);
        bool isAttack = distance <= attackRange;
        this.animator.SetBool("isAttack",isAttack);
        this.animator.SetBool("isRunning",!isAttack);
    }
}
