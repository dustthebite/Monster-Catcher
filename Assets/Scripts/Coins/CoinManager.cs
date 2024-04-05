using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CoinManager : ICoinManager
{
    private int _coins;
    public int Coins() => _coins;
    public event Action OnCoinsChanged;
    public void AddCoins(int amount)
    {
        _coins += amount;
        OnCoinsChanged?.Invoke();
    }
    public void SetCoins(int amount)
    {
        _coins = amount;
        OnCoinsChanged?.Invoke();
    }
    public void SpendCoins(int amount)
    {
        if(_coins < amount){
            Debug.Log("Too little coins to spend");
            return;
        }
        _coins -= amount;
        if(_coins < 0)
        {
            _coins = 0;
        }

        OnCoinsChanged?.Invoke();
    }
}
