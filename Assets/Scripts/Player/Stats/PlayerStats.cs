using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerStats : MonoBehaviour, IPlayerStats, IDamageable
{
    [SerializeField] int maxHp;
    public event Action OnHpChanged;
    int currentHp;
    public int GetCurrentHp() => currentHp;
    public int GetHp() => currentHp;
    public void SetHp(int value)
    { 
        currentHp = value;
        OnHpChanged?.Invoke();
    }
    void Start()
    {
        currentHp = maxHp;
    }
    public void RestoreHp(int hp)
    {
        currentHp += hp;
        if(currentHp >= maxHp)
        RestoreFullHp();
        OnHpChanged?.Invoke();
    }
    public void RestoreFullHp()
    {
        currentHp = maxHp;
        OnHpChanged?.Invoke();
    }
    public void TakeDamage(int hp)
    {
        currentHp -= hp;
        OnHpChanged?.Invoke();
        if (currentHp <= 0)
        Die();
    }
    public void Die()
    {
        Debug.Log("Player death logic");
    }

}
