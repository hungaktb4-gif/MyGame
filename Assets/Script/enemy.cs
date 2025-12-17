using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance = 2f;
    private Vector3 startPos;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
            }
            else
            {
                transform.Translate(Vector2.left*speed*Time.deltaTime);
                if (transform.position.x >= leftBound)
                {
                    movingRight = true;
                    Flip();
                }
            }
        }
    }
    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
