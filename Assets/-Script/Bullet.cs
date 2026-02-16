using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    private ObjectPool pool;
    public Transform Enemy;
    private float detection = 0.5f;
    private LayerMask enemyLayer;
    private void Awake()
    {
        pool = FindObjectOfType<ObjectPool>();
        enemyLayer = LayerMask.GetMask("Enemy");
    }
    void Start()
    {
        Invoke("Delete",0.5f);
    }
     void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position,detection,enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Delete();
        }
    }  
    void Delete()
    {
        CancelInvoke();
        pool.ReturnObject(gameObject);
    }
}
