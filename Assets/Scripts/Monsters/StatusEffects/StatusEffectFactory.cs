using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StatusEffectFactory : IStatusEffectFactory
{
    public IStatusEffect Create(StatusEffects effect, int _lifeSpan, int _damage, Monster _target)
    {
        switch (effect){
            case StatusEffects.Frostbite:
            return new Frostbite(_lifeSpan, _damage, _target);
            case StatusEffects.Combustion:
            return new Combustion(_lifeSpan, _damage, _target);
            case StatusEffects.Absorption:
            return new Absorption(_lifeSpan, _damage, _target);
            case StatusEffects.Curse:
            return new Curse(_lifeSpan, _damage,_target);
            default:
            Debug.LogWarning("Unknown effect, creating frostbite ");
            return new Frostbite(_lifeSpan, _damage, _target); 
        }
    }
}