using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName =  "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    // script chứa thông tin của vật phẩm
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string ItemName = "no-name";
    public int defaultMaxStack = 7;
}
