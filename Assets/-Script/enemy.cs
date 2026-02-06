using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{ 
   public GameObject pointA;
   public GameObject pointB;
   private Animator animator;
   public Transform currentStart;
   public float speed = 2f;
   private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentStart = pointB.transform;
        animator.SetBool("isRunning",true);
    }

    // Update is called once per frameUp
    void Update()
    {
        Vector2 point = currentStart.position - transform.position;
        if(currentStart ==  pointB.transform)
        {
            rb.velocity  = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if(Vector2.Distance(transform.position,currentStart.position) < 1f && currentStart == pointB.transform)
        {   
            Flip();
            currentStart = pointA.transform;
        }
        if(Vector2.Distance(transform.position,currentStart.position) < 1f && currentStart == pointA.transform)
        {   
            Flip();
            currentStart = pointB.transform;
        }
    }
    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position,0.5f);
        Gizmos.DrawLine(pointA.transform.position,pointB.transform.position);
    }
}
