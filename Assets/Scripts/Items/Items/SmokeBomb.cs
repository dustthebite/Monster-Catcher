using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeBomb : IItem
{
    IBattleSystem battleSystem;
    public SmokeBomb(IBattleSystem _battleSystem)
    {
        battleSystem = _battleSystem;
    }
    public void Use()
    {
        battleSystem.Run();
    }
}