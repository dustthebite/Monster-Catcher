using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterFactory
{
    public Monster CreateMonster(int exp, MonsterBase baseStats);
}