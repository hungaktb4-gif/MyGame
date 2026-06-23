using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class JunkDamageReciever : DamageReceiver
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if(this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl",gameObject);
    }
    public override void Reborn()
    {
        this.maxHp = junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        DropManager.Instance.Drop(junkCtrl.JunkSO.dropList);
        this.junkCtrl.JunkDespawn.DespawnObject();
    }
    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }
}
