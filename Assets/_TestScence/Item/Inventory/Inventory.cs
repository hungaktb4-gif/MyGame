using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SaiMonoBehaviour
{
    [SerializeField] protected List<ItemInventory> items = new();
    [SerializeField] protected int maxSlot = 70;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //this.AddItem(ItemCode.IronOre, 5);
        //this.DeductItem(ItemCode.IronOre,2);
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode); //lấy item
        int newCount = itemInventory.itemCount + addCount; // lấy số lượng item hiện có
        if(newCount > itemInventory.maxStack) return false; // vượt quá số lượng tối đa thì không tăng thêm nữa
        itemInventory.itemCount = newCount;
        return true;
    }
    public virtual bool DeductItem(ItemCode itemCode, int amount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - amount;
        if(newCount <= 0) return false;
        itemInventory.itemCount = newCount;
        return true;
    }
    public virtual bool TryDeductItem(ItemCode itemCode, int amount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - amount;
        if(newCount <= 0) return false;
        return true;
    }
    protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if(itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }
    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if(profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,  // viết tắt của itemInventory.itemProfile = profile;
                maxStack = profile.defaultMaxStack   // viết tắt của itemInventory.maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
