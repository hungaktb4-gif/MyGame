using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        ItemDropManager.Instance.Despawn(transform.parent);
        Debug.Log("Đã despawnObject");
    }
}
