using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using TMPro;
public class PlayerStock : MonoBehaviour, IPlayerStock
{
    public event Action OnAddToStock;
    public event Action OnRemoveFromStock;
    public event Action OnSetCurrentMonster;
    MonsterFactory factory;
    IAbilityManager abilityManager;
    Monster currentmonster;
    List<Monster> stock;
    int size = 25;
    public List<Monster> GetStock() => stock;
    const string resourcesPath = "ScriptableObjects/Monsters/";
    void Awake()
    {        
        factory = new MonsterFactory();
        stock = new List<Monster>{
        };

    }
    public void AddToStocks(Monster monster)
    {
        stock.Add(monster);
        OnAddToStock?.Invoke();
    }
    public void RemoveFromStocks(int index)
    {
        stock.RemoveAt(index);
        OnRemoveFromStock?.Invoke();
    }
    public Monster FindMonsterByIndex(int index)
    {
        return stock[index];
    }
    public int GetStockSize()
    {
        return size;
    }
    public int GetEmptyStocksAmmount()
    {
        return size - stock.Count;
    }
    public int GetOccupiedStocksAmount()
    {
        return stock.Count;
    }

    public Monster GetCurrentMonster() => currentmonster;
    public void SetCurrentMonster(int index) 
    {
        currentmonster = stock[index];
        OnSetCurrentMonster?.Invoke();
    }
    public void ResetStock()
    {
        if(stock != null)
        {
            stock = new List<Monster>{};
            OnRemoveFromStock?.Invoke();
        }
    }
}