using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounter: IRandomEncounter
{
    Monster player;
    Monster enemy; 
    IBattleSystem battleSystem;
    public RandomEncounter(Monster _player, Monster _enemy, IBattleSystem _battleSystem)
    {
        player = _player;
        enemy = _enemy;
        battleSystem = _battleSystem;
    }
    public void StartEncounter()
    {
        battleSystem.StartBattle(player, enemy);
    }
}