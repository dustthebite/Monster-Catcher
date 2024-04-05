using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IPlayerStats
{
    public event Action OnHpChanged;
    public void SetHp(int value);
    public int GetHp();
}