using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyMaxHealth = 50;
    public int currentHealth;
    public float damageInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = EnemyMaxHealth;
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("đcm unity toàn làm bố mày khổ ");
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
         Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
