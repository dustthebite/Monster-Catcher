using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class StrikeEffect : MonoBehaviour, IAbilityEffect
{
    IElementManager elementManager;
    [SerializeField] Elements element;
    [SerializeField] int value;
    public void ApplyEffect(Monster caster)
    {
        elementManager = new ElementManager();

        if(elementManager.DoesElementCounters(element, caster.GetTarget().GetElement()))
        caster.GetTarget().TakeDamage(value + 20);
        else
        caster.GetTarget().TakeDamage(value);
    }
}