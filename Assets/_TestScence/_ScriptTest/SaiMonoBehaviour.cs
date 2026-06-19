using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void OnEnable()
    {
        
    }
    protected virtual void Start()
    {
        //for override
    }
    protected virtual void Awake()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {
        // This function for override or..... do something :))
    }
    protected virtual void ResetValue()
    {
        
    }
}
