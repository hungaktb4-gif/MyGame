using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected Transform bulletPrefab;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;

    void Update()
    {
        this.IsShooting();
        //this.Shooting();
    }
    void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if(!this.isShooting) return;
        shootTimer += Time.fixedDeltaTime;
        if(shootTimer < shootDelay) return;
        shootTimer = 0f;
        Vector3 spawnPos = this.transform.parent.position;
        Quaternion rotation = this.transform.parent.rotation;
        //Transform newBullet = Instantiate(this.bulletPrefab,spawnPos,rotation);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPos,rotation);
        if(newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }
    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
    
}
