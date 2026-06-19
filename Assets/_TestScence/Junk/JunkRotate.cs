using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;
    protected virtual void FixedUpdate()
    {
        this.Rotate();
    }
    protected virtual void Rotate()
    {
        Vector3 euler = new Vector3(0,0,1);
        junkCtrl.Model.Rotate(euler*speed*Time.fixedDeltaTime);
    }
}
