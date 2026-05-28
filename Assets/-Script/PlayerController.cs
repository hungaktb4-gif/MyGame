using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HungMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float JumpForce = 15f;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform groundCheck;
    protected GameManger gameManager;
    protected Animator animator;
    protected bool isGrounded;
    protected bool isClamb;
    protected Rigidbody2D rb;
    protected static PlayerController instance;
    public static PlayerController Instance => instance;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        instance = this;
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
        this.Clamp(y,moveInput);
        if(moveInput > 0)transform.localScale = new Vector3(1,1,1);
        else if (moveInput < 0)transform.localScale = new Vector3(-1,1,1);
    }
    protected virtual void Clamp(float y,float moveInput)
    {
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
