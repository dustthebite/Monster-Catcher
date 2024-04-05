using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IPlayerInBattle 
{
    public bool IsPlayerInBattle();
    public void PhysicalAttack();
    public void CastFirstAbility();
    public void CastSecondAbility();
    public void CastThirdAbility();
    public string FirstAbilityName();
    public string SecondLevelAbilityName();
    public string ThirdLevelAbilityName();
}