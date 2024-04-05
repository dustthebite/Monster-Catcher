using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTurn
{
    public Monster GetCaster();
    public Monster GetTarget();
    public void SetCasterAndTarget(Monster _caster, Monster _target);
    public void ChooseRandomAttack();
    public string GetLastAbilityUsed();
}