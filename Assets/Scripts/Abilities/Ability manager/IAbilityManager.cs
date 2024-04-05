using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityManager
{
    //public ILightIceAttack GetLightIceAttack();
    //public void UseAbility(Abilities abilitiy, Monster target);
    public void UseAbility(string abilityName, Monster target);
}