using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface ICoinManager
{
    public void AddCoins(int amount);
    public void SpendCoins(int amount);
    public int Coins();
    public event Action OnCoinsChanged;
    public void SetCoins(int amount);
}
