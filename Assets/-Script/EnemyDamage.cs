using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
   private int damage = 5;
   public PlayerHealth playerHealth;
   private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth = collision.GetComponent<PlayerHealth>();
            InvokeRepeating("DoDamage",0f, 0.5f);    
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth = null;
            CancelInvoke("DoDamage");
        }      
    }
    void DoDamage()
    {
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
