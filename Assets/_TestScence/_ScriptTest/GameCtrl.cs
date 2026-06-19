using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : SaiMonoBehaviour
{
    // script này dùng để liên kết tới các object đặc biệt và có thể được truy cập bởi bất cứ object nào
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;
    protected static GameCtrl instance;
    public static GameCtrl Instance => instance;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if(GameCtrl.instance != null) Debug.LogError("Only 1 Game Ctrl alowed to exists");
        GameCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if(this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindAnyObjectByType<Camera>();
        Debug.Log(transform.name + ": LoadCamera",gameObject);
    }
}
