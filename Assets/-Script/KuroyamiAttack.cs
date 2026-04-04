using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuroyamiAttack : MonoBehaviour
{
    public Transform attackPoint;
    private float attackRange = 0.6f;
    private Animator animator;
    private int numberOfAttack = 0;
    private EnemyHealth enemyHealth;
    public string dataName;
    public HeroData heroData;
    public int damage = 10;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        heroData = Resources.Load<HeroData>(dataName);
    }
    void Start()
    {
        heroData.damageAttack = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            numberOfAttack++;
            Attack();
        }
    }
    void Attack()
    {
        if(numberOfAttack == 1)
        {
            animator.SetTrigger("slashHorizontal");
        }
        else if(numberOfAttack == 2)
        {
            animator.SetTrigger("slashVertical");
            numberOfAttack = 0;
        }
        Invoke("DoDamage",0.2f);
    }
    void DoDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange, LayerMask.GetMask("Enemy"));
        foreach(Collider2D enemy in enemies)
        {
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(heroData.damageAttack);
            }
        }
    }
}
