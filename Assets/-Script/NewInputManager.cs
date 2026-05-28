using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInputManager : MonoBehaviour
{
    protected static NewInputManager instance;
    public static NewInputManager Instance => instance;
    protected bool getMouse;
    public bool onClick => getMouse;

    void Awake()
    {
        if(NewInputManager.instance != null) Debug.LogError("Only 1 NewInputManager only");
        NewInputManager.instance = this;
    }
    void Update()
    {
        this.GetMouseDown();
    }
    protected virtual void GetMouseDown()
    {
        this.getMouse = Input.GetMouseButtonDown(0);
    }
    public virtual bool GetKeyButtonDown(KeyCode keyName)
    {
        return Input.GetKeyDown(keyName);
    }
}
