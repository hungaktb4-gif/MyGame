using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCondition : MonoBehaviour
{
    public float fall = -20f;
    private GameManger gameManager;
    private PlayerHealth health;
    void Update()
    {
        if (!gameManager.isGameOver && transform.position.y < fall)
        {
            gameManager.GameOver();
        }
    }
    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManger>();
        health = FindAnyObjectByType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(1);
            Debug.Log("+1 Money");
        }
        else if(collision.CompareTag("medicine"))
        {
            health.AddHealth(10);
            Destroy(collision.gameObject);
        }
    }
}
