using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HungMonoBehaviour
{
    [SerializeField] protected Image healthBar;
    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected HeroData heroData;
    [SerializeField] protected string dataName;
    protected float damageInterval = 1.5f;
    protected bool isTakingDamage = false;
    protected GameManger gameManager;
    protected SpriteRenderer myColor;
    // Start is called before the first frame update
    void Start()
    {
        this.LoadHealthBar();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.heroData =  Resources.Load<HeroData>(dataName);
        this.myColor = GetComponent<SpriteRenderer>();
    }
    protected virtual void LoadHealthBar()
    {
        GameObject FindFill = GameObject.Find("Fill");
        if(FindFill != null)
        {
            healthBar = FindFill.GetComponent<Image>();
        }
        this.SetHealthBar();
        this.LoadGameManager();
    }
    protected virtual void SetHealthBar()
    {
        heroData.health = maxHealth;
        healthBar.color = Color.green;
    }
    protected virtual void LoadGameManager()
    {
        gameManager = FindObjectOfType<GameManger>();
    }
    public virtual void TakeDamage(int amount)
    {
        heroData.health -= amount;
        StartCoroutine(FlashRed());
        float remainingHealth =  heroData.health / maxHealth;
        this.SetColorForHealthBarWhenTakeDamage(remainingHealth);
    }
    protected virtual void SetColorForHealthBarWhenTakeDamage(float remainingHealth)
    {
        healthBar.fillAmount = remainingHealth;

        if (remainingHealth >= 0.5f) healthBar.color = Color.green;

        else if (remainingHealth > 0.2f) healthBar.color = Color.yellow;

        else healthBar.color = Color.white;

        if (heroData.health <=0) this.Die();
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
        this.SetColorForHealthBarWhenAddHealth(remainingHealth);
    }
    protected virtual void SetColorForHealthBarWhenAddHealth(float remainingHealth)
    {
        healthBar.fillAmount = remainingHealth;

        if (remainingHealth >= 0.5f) healthBar.color = Color.green;

        else if (remainingHealth > 0.2f) healthBar.color = Color.yellow;

        else healthBar.color = Color.white;

        if (heroData.health > 100) heroData.health = 100;
    }
}
