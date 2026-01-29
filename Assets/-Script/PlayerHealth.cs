using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100;
    public float currentHealth;
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
        healthBar.fillAmount =  currentHealth / maxHealth;
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
    public void AddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
