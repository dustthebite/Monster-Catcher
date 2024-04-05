using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Monster")]
public class MonsterBase : ScriptableObject
{
    public string PrefabPath;
    public Sprite sprite ;
    public MonsterType type ;
    public Elements element ;
    public string description ;
    public int maxHp ;
    public int maxSp;
    public int attackDamage;
    public string firstLevelAbilityName ;
    public int firstLevelAbilityCost;
    public string secondLevelAbilityName ;
    public int secondLevelAbilityCost;
    public int expNeededForSecondLevelAbility;
    public string thirdLevelAbilityName ;
    public int thirdLevelAbilityCost;
    public int expNeededForThirdLevelAbility;
}
