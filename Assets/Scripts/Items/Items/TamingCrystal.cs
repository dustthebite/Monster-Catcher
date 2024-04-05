using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamingCrystal : IItem
{
    IBattleSystem battleSystem;
    IPlayerStock stock;
    public TamingCrystal(IBattleSystem _battleSystem, IPlayerStock _stock)
    {
        battleSystem = _battleSystem;
        stock = _stock;
    }
    public void Use()
    {
        stock.AddToStocks(battleSystem.GetEnemyMonster());
        battleSystem.EndBattle();
    }
}
