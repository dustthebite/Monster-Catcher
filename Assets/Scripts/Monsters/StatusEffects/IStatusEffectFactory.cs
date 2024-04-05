using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffectFactory
{
    public IStatusEffect Create(StatusEffects effect, int _lifeSpan, int _damage, Monster _target);
}