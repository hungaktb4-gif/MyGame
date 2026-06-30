using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropManager : Spawner
{
    protected static ItemDropManager instance;
    public static ItemDropManager Instance => instance;

    protected override void Awake()
    {
        if(ItemDropManager.instance != null) Debug.LogError("Only 1 ItemDropManager allowed to exist");
        ItemDropManager.instance = this;
    }
    public virtual void Drop(List<DropRate>dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if(itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
