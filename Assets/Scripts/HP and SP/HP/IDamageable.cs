using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public int GetCurrentHp();
    public void TakeDamage(int hp);
    public void RestoreHp(int hp);
    public void RestoreFullHp();
    public void Die(); // нада би уточнить про паблік тут
}