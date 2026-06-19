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
        this.Send(damageReceiver); // nếu như không có dòng này thì sẽ viết như ở dưới 
        //damageReceiver.Deduct(this.damage);
        //this.DestroyObject();
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
