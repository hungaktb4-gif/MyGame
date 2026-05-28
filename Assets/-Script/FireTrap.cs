using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : HungMonoBehaviour
{
    protected int damage = 50;
    protected Animator animator;
    protected PlayerHealth playerHealth;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.animator = GetComponent<Animator>();
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
    protected override void Attack()
    {
        bool isFire = animator.GetBool("isFire");
        if(playerHealth != null&&isFire)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
