using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounterFactory : IRandomEncounterFactory
{
    IBattleSystem battleSystem;
    public RandomEncounterFactory(IBattleSystem _battleSystem)
    {
        battleSystem = _battleSystem;
    }
    public RandomEncounter CreateRandomEncounter(Monster player, Monster enemy)
    {
        return new RandomEncounter(player, enemy, battleSystem);
    }
}