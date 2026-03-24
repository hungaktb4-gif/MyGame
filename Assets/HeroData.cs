using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "NewHeroData",menuName = "Hero System/ Hero Data")]
public class HeroData : ScriptableObject
{
    public int damageAttack;
    public float health;
    public GameObject heroPrefab;
    public Sprite heroIcon;
    public string heroName;
    public int damageSkill;
    public int damageKick;
}
