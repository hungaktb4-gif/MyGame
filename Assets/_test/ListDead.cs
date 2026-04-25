using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDead : ListChild
{
    // Start is called before the first frame update
    void Start()
    {
        this.ShowAllChildren();
    }
    protected override void ShowAllChildren()
    {
        foreach(Transform child in transform)
        {
            if(this.IsDead(child))
            {
                Debug.Log(transform.name + " "+"Dead");
            }
        }
    }
    // Update is called once per frame
    protected bool IsDead(Transform monster)
    {
        if(monster.name.Contains("Dead")) return true;
        return false;
    }
}
