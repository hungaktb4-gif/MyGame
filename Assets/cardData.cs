using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "card" ,menuName = "cardData")]
public class cardData : ScriptableObject
{
    public int cardindex;
    public string cardName;
}
