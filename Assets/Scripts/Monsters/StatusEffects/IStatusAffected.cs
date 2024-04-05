using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IStatusAffected
{
    public List<IStatusEffect> GetStatusEffects();
    public void AddStatusEffect(IStatusEffect effect);
    public void RemoveStatusEffect(IStatusEffect effect);
    public void NullifyStatusEffects();
}