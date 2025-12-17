using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 5;
    public float damageInterVal = 1.5f;
    private bool isPlayerInrange = false;
    private float nextDamageTime = 0f;
    private PlayerHealth playerHealth;
    private Animator animator;
    public float attackRange = 1.5f;
    public Transform Player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInrange = true;
            playerHealth = other.GetComponent<PlayerHealth>();        
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInrange = false;
        }
    }
    void Update()
    {
        UpdateAnimation();
        if (isPlayerInrange && Time.time >= nextDamageTime)
        {
            nextDamageTime = Time.time + damageInterVal;
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
    private void UpdateAnimation()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
        bool isAttack = distanceToPlayer <= attackRange;
        animator.SetBool("isAttack",isAttack);
    }
}
