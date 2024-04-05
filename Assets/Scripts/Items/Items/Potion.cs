using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : IItem
{
    int hp;
    int sp;
    Monster target;
    public Potion(int _hp, int _sp, Monster _target)
    {
        hp = _hp;
        sp = _sp;
        target = _target;
    }
    public void Use()
    {
        target.RestoreHp(hp);
        target.AddSp(sp);
    }
}
