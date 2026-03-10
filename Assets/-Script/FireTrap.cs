using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private int damage = 50;
    private Animator animator;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetFireTrue()
    {
        animator.SetBool("isFire",true);
    }
    public void SetFireFalse()
    {
        animator.SetBool("isFire",false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth = other.GetComponent<PlayerHealth>();
        InvokeRepeating("Attack",0.1f,0.6f);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        playerHealth = null;
        CancelInvoke();   
    }
    void Attack()
    {
        bool isFire = animator.GetBool("isFire");
        if(playerHealth != null&&isFire)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
