using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 100;
    public HeroData heroData;
    public string dataName;
    public float damageInterval = 1.5f;
    private bool isTakingDamage = false;
    private GameManger gameManager;
    private SpriteRenderer myColor;
    private void Awake()
    {
        heroData =  Resources.Load<HeroData>(dataName);
        myColor = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject FindFill = GameObject.Find("Fill");
        if(FindFill != null)
        {
            healthBar = FindFill.GetComponent<Image>();
        }
        heroData.health = maxHealth;
        healthBar.color = Color.green;
        gameManager = FindObjectOfType<GameManger>();
    }
    public void TakeDamage(int amount)
    {
        heroData.health -= amount;
        StartCoroutine(FlashRed());
        float remainingHealth =  heroData.health / maxHealth;
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
        if (heroData.health <=0)
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
        heroData.health += health;
        StartCoroutine(FlashGreen());
        float remainingHealth = heroData.health / maxHealth;
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
        if (heroData.health > 100)
        {
            heroData.health = 100;
        }
    }
}
