using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public interface IPlayerStockUi
{
    public TMP_Dropdown GetDropdown();
    public string GenerateUnitInfo(Monster unit);
}