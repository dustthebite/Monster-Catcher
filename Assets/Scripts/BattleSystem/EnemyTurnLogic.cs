using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyTurnLogic : IEnemyTurn
{
    Monster caster;
    Monster target;
    public Monster GetCaster() => caster;
    public Monster GetTarget() => target;
    string lastUsed = " ";
    public string GetLastAbilityUsed() => lastUsed;
    public void SetCasterAndTarget(Monster _caster, Monster _target)
    {
        caster = _caster;
        target = _target;
        caster.SetTarget(target);
    }
    public void ChooseRandomAttack()
    {
        Dictionary<int, Func<bool>> attackDictionary = new Dictionary<int, Func<bool>>(){ 
            {1, CastFirstAbility},
            {2, CastSecondAbility},
            {3, CastThirdAbility},
            {4, PhysicalAttack}
        };
        bool success = false;
        while(!success)
        {
            int attack = UnityEngine.Random.Range(1,5);
            success = attackDictionary[attack].Invoke();
        }
    }
    bool CastFirstAbility()
    {
        if(caster.GetCurrentSp() >= caster.GetFirstAbilityCost()){
            caster.CastFirstAbility();
            Debug.Log("EnemyTurnLogic : using first ability");
            lastUsed = caster.GetFirstLevelAbilityName();
            return true;
        }
        else
        return false;
    }
    bool CastSecondAbility()
    {
        if(caster.GetCurrentSp() >= caster.GetSecondAbilityCost() && caster.GetCurrentExp() >= caster.GetExpNeedeForSecondLevelAbility()){
            Debug.Log("EnemyTurnLogic : using second ability");
            caster.CastSecondAbility();
            lastUsed = caster.GetSecondLevelAbilityName();
            return true;
        }
        else
        return false;
    }
    bool CastThirdAbility()
    {
        if(caster.GetCurrentSp() >= caster.GetThirdAbilityCost() && caster.GetCurrentExp() >= caster.GetExpNeedeForThirdLevelAbility()){
            Debug.Log("EnemyTurnLogic : using third ability");
            caster.CastThirdAbility();
            lastUsed = caster.GetThirdLevelAbilityName();
            return true;
        }
        else
        return false;
    }
    bool PhysicalAttack()
    {
        Debug.Log("EnemyTurnLogic : physical attack");
        lastUsed = "physical attack";
        caster.GetTarget().TakeDamage(caster.GetAttackDamage());
        return true;
    }
}