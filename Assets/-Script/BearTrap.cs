using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    private Animator animator;
    private int damage = 20;
    private PlayerHealth playerHealth;
    public Transform Player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetBool("isTrapped",true);
            playerHealth = other.GetComponent<PlayerHealth>();
            StartCoroutine(DoDamage());
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerHealth = null;
            CancelInvoke("DoDamage");
        }
    }
    IEnumerator DoDamage()
    {
        yield return new WaitForSeconds(0.2f);
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
        yield return new WaitForSeconds(1f);
        animator.SetBool("isTrapped",false);
    }
} 