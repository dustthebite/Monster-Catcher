using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster
{
    public Sprite GetSprite();
    public MonsterType GetMonsterType();
    public Elements GetElement();
    public string GetDescription();
    public int GetDamageReduction();
    public void SetDamageReduction(int damageReduction);
    public void NullifyDamageReduction();
    public int GetCurrentExp();
    public void AddExp(int _exp);
    public int GetAttackDamage();
    public void CastFirstAbility();
    public void CastSecondAbility();
    public void CastThirdAbility();
    public int GetFirstAbilityCost();
    public int GetSecondAbilityCost();
    public int GetThirdAbilityCost();
    public int GetExpNeedeForSecondLevelAbility();
    public int GetExpNeedeForThirdLevelAbility();
    public string GetFirstLevelAbilityName();
    public string GetSecondLevelAbilityName();
    public string GetThirdLevelAbilityName();
    public int GetCurrentSp();
    public void RestoreFullSp();
    public void AddSp(int _sp);
    public Monster GetTarget();
    public void SetTarget(Monster target);
    public MonsterBase GetBaseStats();
}
