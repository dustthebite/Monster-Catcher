using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceEffect : MonoBehaviour, IAbilityEffect
{
    [SerializeField] int value;
    [SerializeField] int lifeSpan;
    public void ApplyEffect(Monster caster)
    {
        caster.AddStatusEffect(new DamageReductionIncrease(lifeSpan, value, caster));
    }
}
