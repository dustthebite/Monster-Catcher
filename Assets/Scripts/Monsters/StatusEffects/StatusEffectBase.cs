using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Status Effect")]
public class StatusEffectBase : ScriptableObject
{
    public StatusEffects effect; 
    public int duration; //in moves !!!
    public int value;
}
