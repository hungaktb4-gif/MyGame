using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropRate
{
   // script liên quan đến tỷ lệ rớt đồ 
   public ItemSO itemSO; // vật phẩm muốn rơi
   public int dropRate;
   public int minDrop;
   public int maxDrop;
}
