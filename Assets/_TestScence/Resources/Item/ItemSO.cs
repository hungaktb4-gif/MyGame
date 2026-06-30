using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]
public class ItemSO : ScriptableObject
{
    // script có chứa dữ liệu của vật phẩm 
    public ItemCode itemCode = ItemCode.NoItem;
    public string itemName = "Item";
}
