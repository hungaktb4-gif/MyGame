using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyMaxHealth = 50;
    public string dataName;
    public EnemyData enemyData;
    public int currentHealth;
    public float damageInterval = 1f;
    private SpriteRenderer enemyColor;

    private void Awake()
    {
        enemyData = Resources.Load<EnemyData>(dataName);
        enemyColor = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        enemyData.health= EnemyMaxHealth;
    }
    public void TakeDamage(int amount)
    {
        enemyData.health -= amount;
        StartCoroutine(FlashRed());
        if (enemyData.health <= 0)
        {
            Die();
        }
    }
    IEnumerator FlashRed()
    {
        enemyColor.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        enemyColor.color = Color.white;
    }
    void Die()
    {
         Destroy(gameObject);
    }
}
