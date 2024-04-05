using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : IStatusEffect
{
    public Absorption(StatusEffectBase _baseStats, Monster _target)
    {
        baseStats = _baseStats;
        target = _target;
        lifeSpan = baseStats.duration;
        damage = baseStats.value;
    }
    public Absorption(int _lifeSpan, int _damage, Monster _target)
    {
        baseStats = Resources.Load<StatusEffectBase>("ScriptableObjects/StatusEffects/Absorption");
        target = _target;
        lifeSpan = _lifeSpan;
        damage = _damage;
    }
    int damage;
    int lifeSpan;
    StatusEffects effect = StatusEffects.Absorption;
    StatusEffectBase baseStats;
    Monster target;
    public int GetLifeSpan() => lifeSpan;
    public void SetLifespan(int _lifeSpan) => lifeSpan = _lifeSpan;
    public StatusEffects GetStatusEffectType() => effect;
    public void TriggerEffect()
    {
        Debug.Log("Absorption is working!");
        target.TakeDamage(damage);
        lifeSpan--;
    }
}
