using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUI
{
    public void UpdateCoins();
    public void UpdatePlayerHp();
    /*
    public void UpdateCoins(int value);
    public void UpdatePlayerHp(int value);
    */
    public void UpdateBiomsText(string value);
}
