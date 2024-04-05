using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData:ISaveData
{
    public int hp;
    public float xPos;
    public float yPos;
    public int coins;
    public int smokeBombs;
    public int tamingCrystals;
    public int hpPotions;
    public int spPotions;
    public int universalPotions;
    public UnitData[] units;
}