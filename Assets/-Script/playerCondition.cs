using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCondition : HungMonoBehaviour
{
    [SerializeField] protected float fall = -20f;
    protected GameManger gameManager;
    protected PlayerHealth health;
    void Update()
    {
        this.CheckGameOver();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameManager();
        this.LoadHealth();
    }
    protected virtual void CheckGameOver()
    {
        if (!gameManager.isGameOver && transform.position.y < fall) gameManager.GameOver();
    }
    protected virtual void LoadGameManager()
    {
        if(this.gameManager != null) return;
        this.gameManager = FindAnyObjectByType<GameManger>();
    }
    protected virtual void LoadHealth()
    {
        this.health = FindAnyObjectByType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            this.gameManager.AddScore(1);
            Debug.Log("+1 Money");
        }
        else if(collision.CompareTag("medicine"))
        {
            this.health.AddHealth(10);
            Destroy(collision.gameObject);
        }
    }
}
