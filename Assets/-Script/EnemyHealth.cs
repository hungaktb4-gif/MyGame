using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyMaxHealth = 50;
    public int currentHealth;
    public float damageInterval = 1f;
    private SpriteRenderer enemyColor;

    private void Awake()
    {
        enemyColor = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = EnemyMaxHealth;
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("đcm unity toàn làm bố mày khổ ");
        currentHealth -= amount;
        StartCoroutine(FlashRed());
        if (currentHealth <= 0)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
