using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : IMonsterFactory
{
    public Monster CreateMonster(int exp, MonsterBase baseStats)
    {
        return new Monster(exp, baseStats);
    }
}