using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRandomEncounterFactory
{
    public RandomEncounter CreateRandomEncounter(Monster player, Monster enemy);
}