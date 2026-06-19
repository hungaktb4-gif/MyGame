using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : SaiMonoBehaviour
{
    // dùng để liên kết tới bulletCtrl lý do cần tạo ra class này là vì hành động liên kết tới bulletCtrl có thể xảy ra nhiều lần
    [Header("BulletAbstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl => bulletCtrl;
    // script này dùng để lấy liên kết với bulletCtrl
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver() // LoadBulletCtrl
    {
        if(this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadDamageReceiver",gameObject);       
    }
}
