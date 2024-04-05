using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffect 
{
    public int GetLifeSpan();
    public void SetLifespan(int value);
    public void TriggerEffect();
    public StatusEffects GetStatusEffectType();
}