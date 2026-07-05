using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>(); // kiểm tra xem obj(đối tượng va chạm)có script quản lý máu ko
        if(damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreatImpactFX();
    }
    protected virtual void CreatImpactFX()
    {
        string fxName = this.GetImpactFXName();
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Quaternion rotationEffect = Quaternion.Euler(0,0,-90);
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName,hitPos, hitRot*rotationEffect);
        fxImpact.gameObject.SetActive(true);
    }
    protected string GetImpactFXName()
    {
        return FXSpawner.impact1;
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
