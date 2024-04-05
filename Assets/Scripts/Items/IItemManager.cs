using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IItemManager
{
    public event Action OnSmokeBombsAmountChanged;
    public event Action OnTamingCrystalsAmountChanged;
    public event Action OnHpPotionsAmountChanged;
    public event Action OnSpPotionsAmountChanged;
    public event Action OnUniversalPotionsAmountChanged;
    public int GetTamingCrystalsAmount();
    public int GetSmokebombsAmount();
    public int GetHpPotionsAmount();
    public int GetSpPotionsAmount();
    public int GetUniversalPotionsAmount();
    public void AddTamingCrystal(int amount);
    public void AddSmokebomb(int amount);
    public void AddHpPotion(int amount);
    public void AddSpPotion(int amount);
    public void AddUniversalPotion(int amount);
    public void SetTamingCrystal(int amount);
    public void SetSmokebomb(int amount);
    public void SetHpPotion(int amount);
    public void SetSpPotion(int amount);
    public void SetUniversalPotion(int amount);
    public void UseTamingCrystal();
    public void UseSmokebomb();
    public void UseHpPotion();
    public void UseSpPotion();
    public void UseUniversalPotion();
}