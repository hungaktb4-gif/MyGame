using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName ="EnemyData" )]
public class EnemyData : ScriptableObject
{
    public int damage;
    public int health;

}
