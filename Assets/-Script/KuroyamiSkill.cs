using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class KuroyamiSkill : MonoBehaviour
{
    public Transform attackPoint;
    private float attackRange = 0.6f;
    private Animator animator;
    private EnemyHealth enemyHealth;
    public string dataName;
    private int damage = 50;
    public HeroData heroData;
    private int cooldown = 10;
    private float nextDamageTime = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        heroData = Resources.Load<HeroData>(dataName);
    }
    void Start()
    {
        heroData.damageSkill = damage;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }
    void Attack()
    {
        if(Time.time <= nextDamageTime)
            return;
        animator.SetTrigger("castSkill");
        Invoke("DoDamage",0.3f);
        nextDamageTime = Time.time + cooldown;
    }
    void DoDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,LayerMask.GetMask("Enemy"));
        foreach(Collider2D enemy in enemies)
        {
            enemyHealth = enemy.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(heroData.damageSkill);
            }
        }
    }
}
