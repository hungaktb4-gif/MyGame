using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float Delay = 2f;
    [SerializeField] protected float timer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }
    protected virtual void ResetTimer()
    {
        this.timer = 0f;
    }
    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if(this.timer > this.Delay) return true;
        return false;
    }
}
