using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public interface IPlayerStock 
{   
    public event Action OnAddToStock;
    public event Action OnRemoveFromStock;
    public event Action OnSetCurrentMonster;
    public Monster GetCurrentMonster();
    public List<Monster> GetStock();
    public void AddToStocks(Monster monster);
    public void RemoveFromStocks(int index);
    public Monster FindMonsterByIndex(int index);
    public int GetStockSize();
    public int GetEmptyStocksAmmount();
    public int GetOccupiedStocksAmount();
    public void SetCurrentMonster(int index);
    public void ResetStock();
}