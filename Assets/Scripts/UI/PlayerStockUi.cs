using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerStockUi : MonoBehaviour, IPlayerStockUi
{
    [SerializeField] TMP_Dropdown dropdown;

    public TMP_Dropdown GetDropdown() => dropdown;

    public string GenerateUnitInfo(Monster unit)
    {
        return $"{unit.GetMonsterType().ToString()} HP: {unit.GetCurrentHp()} SP:{unit.GetCurrentSp()} EXP: {unit.GetCurrentExp()}";
    }
}
