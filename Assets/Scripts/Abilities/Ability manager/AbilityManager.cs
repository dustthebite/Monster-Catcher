using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
public class AbilityManager : IAbilityManager
{
    const string resourcesPath = "Prefabs/Abilities/";
    public void UseAbility(string abilityName, Monster caster)
    {
        var prefab = Resources.Load<GameObject>(resourcesPath + abilityName.Replace(" ", ""));
        if(prefab != null)
        {
            var effects = prefab.GetComponents<IAbilityEffect>();
            foreach (var effect in effects)
            {
                effect.ApplyEffect(caster);
            }
        }
        else
        {
            Debug.LogError($"Unknown ability {abilityName}");
        }

    }
}