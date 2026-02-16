using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Animator animator;
    private int damage = 10;
    public PlayerHealth playerHealth;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetRisingTrue()
    {
        animator.SetBool("isRising",true);
    }
    public void isRisingFalse()
    {
        animator.SetBool("isRising",false);
    }
    void OnTriggerEnter2D(Collider2D other )
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            InvokeRepeating("DoDamage",0.1f,0.5f);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealth = null;
            CancelInvoke();
        }
    }
    void DoDamage()
    {
        bool isRising = animator.GetBool("isRising");
        Debug.Log("check đc ko: "+isRising);
        if(playerHealth != null&&isRising)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
