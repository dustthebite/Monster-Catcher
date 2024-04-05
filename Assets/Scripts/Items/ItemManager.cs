using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
public class ItemManager : MonoBehaviour, IItemManager
{
    [Inject] IBattleSystem battleSystem;
    [Inject] IPlayerStock stock;
    [Inject] IPlayerStats playerStats;
    public event Action OnSmokeBombsAmountChanged;
    public event Action OnTamingCrystalsAmountChanged;
    public event Action OnHpPotionsAmountChanged;
    public event Action OnSpPotionsAmountChanged;
    public event Action OnUniversalPotionsAmountChanged;
    int tamingCrystalsAmount = 0;
    int smokebombsAmount = 0;
    int hpPotionsAmount = 0;
    int spPotionsAmount = 0;
    int universalPotionsAmount = 0;
    SmokeBomb smokeBomb;
    TamingCrystal tamingCrystal;
    Potion hpPotion;
    Potion spPotion;
    Potion universalPotion;
    public int GetTamingCrystalsAmount() => tamingCrystalsAmount;
    public int GetSmokebombsAmount() => smokebombsAmount;
    public int GetHpPotionsAmount() => hpPotionsAmount;
    public int GetSpPotionsAmount() => spPotionsAmount;
    public int GetUniversalPotionsAmount() => universalPotionsAmount;
    public void AddTamingCrystal(int amount)
    {
        tamingCrystalsAmount += amount;
        OnTamingCrystalsAmountChanged?.Invoke();
    }
    public void AddSmokebomb(int amount)
    {
        smokebombsAmount += amount;
        OnSmokeBombsAmountChanged?.Invoke();
    }
    public void AddHpPotion(int amount)
    {
        hpPotionsAmount += amount;
        OnHpPotionsAmountChanged?.Invoke(); 
    }
    public void AddSpPotion(int amount) 
    {
        spPotionsAmount += amount;
        OnSpPotionsAmountChanged?.Invoke();
    }
    public void AddUniversalPotion(int amount)
    {
        universalPotionsAmount += amount;
        OnUniversalPotionsAmountChanged?.Invoke();
    }public void SetTamingCrystal(int amount)
    {
        tamingCrystalsAmount = amount;
        OnTamingCrystalsAmountChanged?.Invoke();
    }
    public void SetSmokebomb(int amount)
    {
        smokebombsAmount = amount;
        OnSmokeBombsAmountChanged?.Invoke();
    }
    public void SetHpPotion(int amount)
    {
        hpPotionsAmount = amount;
        OnHpPotionsAmountChanged?.Invoke(); 
    }
    public void SetSpPotion(int amount) 
    {
        spPotionsAmount = amount;
        OnSpPotionsAmountChanged?.Invoke();
    }
    public void SetUniversalPotion(int amount)
    {
        universalPotionsAmount = amount;
        OnUniversalPotionsAmountChanged?.Invoke();
    }
    void Start()
    {
        battleSystem.OnBattleStarted += HandleItems;
    }

    void HandleItems()
    {
        smokeBomb = new SmokeBomb(battleSystem);
        tamingCrystal = new TamingCrystal(battleSystem, stock);
        hpPotion = new Potion(30, 0, battleSystem.GetPlayerMonster());
        spPotion = new Potion(0, 30, battleSystem.GetPlayerMonster());
        universalPotion = new Potion(15, 15, battleSystem.GetPlayerMonster());
    }

    void OnDestroy()
    {
        battleSystem.OnBattleStarted -= HandleItems;
    }
    public void UseTamingCrystal()
    {
        if(tamingCrystalsAmount > 0)
        {
            tamingCrystal.Use();
            tamingCrystalsAmount--;
            OnTamingCrystalsAmountChanged?.Invoke();
            battleSystem.PassTurnToEnemy();
        }
    }
    public void UseSmokebomb()
    {
        if(smokebombsAmount > 0){
            smokeBomb.Use();
            smokebombsAmount--;
            OnSmokeBombsAmountChanged?.Invoke();
            battleSystem.PassTurnToEnemy();
        }
    }
    public void UseHpPotion()
    {
        if(hpPotionsAmount > 0){
            hpPotion.Use();
            hpPotionsAmount--;
            OnHpPotionsAmountChanged?.Invoke();
            battleSystem.PassTurnToEnemy();
        }
    }
    public void UseSpPotion()
    {
        if(spPotionsAmount > 0){
            spPotion.Use();
            spPotionsAmount--;
            OnSpPotionsAmountChanged?.Invoke();
            battleSystem.PassTurnToEnemy();
        }
    }
    public void UseUniversalPotion()
    {
        if(universalPotionsAmount > 0){
            universalPotion.Use();
            universalPotionsAmount--;
            OnUniversalPotionsAmountChanged?.Invoke();
            battleSystem.PassTurnToEnemy();
        }
    }
}
