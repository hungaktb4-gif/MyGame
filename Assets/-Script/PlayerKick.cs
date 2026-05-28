using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : HungMonoBehaviour
{
    [SerializeField] protected int damage = 15;
    [SerializeField] protected HeroData heroData;
    [SerializeField] protected string dataName;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform attackPoint;
    protected EnemyHealth enemyHealth;
    protected PlayerHealth playerHealth;
    protected int numberOfKicks;
    protected int attackRange = 2;
    protected bool canKick = true;
    protected float kickTime = 0f;
    protected float nextKickTime = 0.2f;

    protected override void LoadComponents()
    {
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        heroData = Resources.Load<HeroData>(dataName);
        heroData.damageKick = damage;
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        this.CastSkill();
    }
    protected virtual bool CanKick()
    {
        this.canKick = NewInputManager.Instance.GetKeyButtonDown(KeyCode.K);
        return canKick;
    }
    protected virtual void CastSkill()
    {
        if(!this.CanKick()) return;
        this.numberOfKicks++;
        this.Attack();
        if(this.numberOfKicks >= 5)
        {
            StartCoroutine(WaitForKick());
        }
    }
    protected override void Attack()
    {
        if(Time.time <= kickTime) return;
        animator.SetBool("isKick",true);
        Invoke("CheckEnemies",0.1f);
        kickTime = Time.time + nextKickTime;
    }
    public void CheckEnemies()
    {
        Collider2D[] hitsEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,LayerMask.GetMask("Enemy"));
        this.AttackEnemies(hitsEnemies);
    }
    protected virtual void AttackEnemies(Collider2D[] hitsEnemies)
    {
        foreach(Collider2D enemies in hitsEnemies)
        {
            this.DoDamageAndRestoreHealth(enemies);
        }
        animator.SetBool("isKick",false);
    }
    protected void DoDamageAndRestoreHealth(Collider2D enemies)
    {
        enemyHealth = enemies.GetComponent<EnemyHealth>();
        if(enemies != null)
        {
            enemyHealth.TakeDamage(heroData.damageKick);
            playerHealth.AddHealth(5);
        }
    }
    IEnumerator WaitForKick()
    {
        canKick = false;
        numberOfKicks = 5;
        yield return new WaitForSeconds(3f);
        numberOfKicks = 0;
        canKick = true;
    }
    void OnDrawGizMosSellect()
    {
        if(attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
