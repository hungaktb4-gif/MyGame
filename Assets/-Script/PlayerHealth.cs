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
    private SpriteRenderer myColor;
    private void Awake()
    {
        myColor = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.color = Color.green;
        gameManager = FindObjectOfType<GameManger>();
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(FlashRed());
        float remainingHealth =  currentHealth / maxHealth;
        healthBar.fillAmount = remainingHealth;
        if (remainingHealth >= 0.5f)
        {
            healthBar.color = Color.green;
        }
        else if (remainingHealth > 0.2f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.white;
        }
        if (currentHealth <=0)
        {
            Die();
        }
    }
    IEnumerator FlashRed()
    {
        myColor.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        myColor.color = Color.white; 
    }
    IEnumerator FlashGreen()
    {
        myColor.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        myColor.color = Color.white;
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
        StartCoroutine(FlashGreen());
        float remainingHealth = currentHealth / maxHealth;
        healthBar.fillAmount = remainingHealth;
        if (remainingHealth >= 0.5f)
        {
            healthBar.color = Color.green;
        }
        else if (remainingHealth > 0.2f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.white;
        }
        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }
}
