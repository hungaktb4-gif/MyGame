using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float JumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private GameManger gameManager;
    private Animator animator;
    private bool isGrounded;
    private bool isClamb;
    private Rigidbody2D rb;
    public static PlayerController Instance{get;set;}
    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManger>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver()) return;
        HandleMovement(); 
        HandleJump();
        UpdateAnimation();  
    }
    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(isClamb)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x,y*moveSpeed);
        }
        else
        {
            rb.gravityScale = 5;
            rb.velocity = new Vector2(moveInput*moveSpeed, rb.velocity.y);
        }
        if(moveInput > 0)transform.localScale = new Vector3(1,1,1);
        else if (moveInput < 0)transform.localScale = new Vector3(-1,1,1);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            if(Mathf.Abs(Input.GetAxisRaw("Vertical"))>0.1f)
            {
                isClamb = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isClamb = false;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
           rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        animator.SetBool("isRunning",isRunning);
    }
}
