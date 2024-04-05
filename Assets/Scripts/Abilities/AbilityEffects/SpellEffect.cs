using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SpellEffect : MonoBehaviour, IAbilityEffect
{
    IStatusEffectFactory effectFactory;
    [SerializeField] StatusEffects effect;
    [SerializeField] int damage;
    [SerializeField] int lifespan;
    public void ApplyEffect(Monster caster)
    {
        effectFactory = new StatusEffectFactory();
        caster.GetTarget().AddStatusEffect(effectFactory.Create(effect, lifespan, damage, caster.GetTarget()));
    }
}