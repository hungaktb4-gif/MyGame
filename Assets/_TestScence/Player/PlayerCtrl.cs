using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : SaiMonoBehaviour
{
    [SerializeField] protected ShipCtrl currentShip;
    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;
    public ShipCtrl CurrentShip => currentShip;
    protected static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if(PlayerCtrl.instance != null) Debug.LogError("Only 1 PlayerCtrl allowed to exist");
        PlayerCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerPickUp();
    }
    protected virtual void LoadPlayerPickUp()
    {
        if(this.playerPickup != null) return;
        this.playerPickup = transform.GetComponentInChildren<PlayerPickup>();
        Debug.Log(transform.name + ": LoadPlayerPickup",gameObject);
    }
}
