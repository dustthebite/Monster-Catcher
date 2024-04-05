using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReductionIncrease : IStatusEffect
{
    public DamageReductionIncrease(StatusEffectBase _baseStats, Monster _target)
    {
        baseStats = _baseStats;
        target = _target;
        lifeSpan = baseStats.duration;
        value = baseStats.value;
    }
    public DamageReductionIncrease(int _lifeSpan, int _value, Monster _target)
    {
        //baseStats = Resources.Load<StatusEffectBase>("ScriptableObjects/StatusEffects/DamageReductionIncrease");
        target = _target;
        lifeSpan = _lifeSpan;
        value = _value;
    }
    int value;
    int lifeSpan;
    StatusEffects effect = StatusEffects.DamageReductionIncrease;
    StatusEffectBase baseStats;
    Monster target;
    public int GetLifeSpan() => lifeSpan;
    public void SetLifespan(int _lifeSpan) => lifeSpan = _lifeSpan;
    public StatusEffects GetStatusEffectType() => effect;
    public void TriggerEffect()
    {
        Debug.Log("DamageReductionIncrease is working!");
        target.SetDamageReduction(value);
        lifeSpan--;
    }
}
