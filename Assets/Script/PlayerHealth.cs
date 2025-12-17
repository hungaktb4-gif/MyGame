using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float damageInterval = 1.5f;
    private bool isTakingDamage = false;
    private GameManger gameManager;
    // Start is called before the first frame update
    void Start()
    {
       currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManger>();
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Hp: "+currentHealth);
        if (currentHealth <=0)
        {
            Die();
        }
    }
    void Die()
    {
        gameManager.GameOver();
    }
    public IEnumerator DamageOverTime(int damagePerTick)
    {
        isTakingDamage = true;
        while (isTakingDamage)
        {
            TakeDamage(damagePerTick);
            yield return new WaitForSeconds(damageInterval);
        }
    }
    public void StopDamage()
    {
        isTakingDamage = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
