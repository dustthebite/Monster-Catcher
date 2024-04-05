using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : IStatusEffect
{
    
    public Curse(StatusEffectBase _baseStats, Monster _target)
    {
        baseStats = _baseStats;
        target = _target;
        lifeSpan = baseStats.duration;
        damage = baseStats.value;
    }
    public Curse(int _lifeSpan, int _damage, Monster _target)
    {
        baseStats = Resources.Load<StatusEffectBase>("ScriptableObjects/StatusEffects/Curse");
        target = _target;
        lifeSpan = _lifeSpan;
        damage = _damage;
    }
    int damage;
    int lifeSpan;
    StatusEffects effect = StatusEffects.Curse;
    StatusEffectBase baseStats;
    Monster target;
    public int GetLifeSpan() => lifeSpan;
    public void SetLifespan(int _lifeSpan) => lifeSpan = _lifeSpan;
    public StatusEffects GetStatusEffectType() => effect;
    public void TriggerEffect()
    {
        Debug.Log("Curse is working!");
        target.TakeDamage(damage);
        lifeSpan--;
    }
}
