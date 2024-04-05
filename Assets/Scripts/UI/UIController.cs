using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Zenject;
public class UIController : MonoBehaviour,IUI
{
    [Inject] ICoinManager coinManager;
    [Inject] IPlayerStock stock;
    [Inject] IBattleSystem battleSystem;
    [Inject] IBiomManager biomManager;
    [Header("Canvas")]
    [SerializeField] GameObject canvas;
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI playerHpText;
    [SerializeField] TextMeshProUGUI biomsText;
    void Start()
    {
        coinManager.OnCoinsChanged += UpdateCoins;
        playerStats.OnHpChanged += UpdatePlayerHp;
        stock.OnAddToStock += HandleAddToStock;
        stock.OnRemoveFromStock += HandleRemoveFromStock;
        stock.OnSetCurrentMonster += HandleSetCurrentMonster;
        battleSystem.OnBattleStarted += HandleBattleStarted;
        battleSystem.OnBattleEnded += HandleEndOfBattle;
        biomManager.OnCurrentBiomChange += HandleBiomChange;
        UpdateCoins();
        //UpdatePlayerHp();
        dropdown.ClearOptions();
        dropdown.AddOptions(DropdownInfo());
        dropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(SetCurrentMonster));
    }
    void SetCurrentMonster(int index) => stock.SetCurrentMonster(index);
    
    List<TMP_Dropdown.OptionData> DropdownInfo()
    {
        List<TMP_Dropdown.OptionData> dropdownOptionData = new List<TMP_Dropdown.OptionData>();
        foreach(Monster stockItem in stock.GetStock()){
            dropdownOptionData.Add(new TMP_Dropdown.OptionData(GenerateUnitInfo(stockItem), stockItem.GetSprite()));
        }
        return dropdownOptionData;
    }

    void HandleBiomChange()
    {
        biomsText.text = biomManager.GetCurrentBiom().GetBiomeName();
    }

    void HandleBattleStarted()
    {
        canvas.SetActive(false);
    }
    
    void HandleEndOfBattle()
    {
        canvas.SetActive(true);
        dropdown.ClearOptions();
        dropdown.AddOptions(DropdownInfo());
    }

    void HandleSetCurrentMonster()
    {
        //currently empty, made for test purposes
    }
    void HandleAddToStock()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(DropdownInfo());
    }
    void HandleRemoveFromStock()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(DropdownInfo());
    }
    string GenerateUnitInfo(Monster unit)
    {
        return $"{unit.GetMonsterType().ToString()} HP: {unit.GetCurrentHp()} SP:{unit.GetCurrentSp()} EXP: {unit.GetCurrentExp()}";
    }
    public void UpdateCoins()
    {
        coinsText.text = $"Coins: {coinManager.Coins()}";
    }
    public void UpdatePlayerHp()
    {
        playerHpText.text = $"HP: {playerStats.GetCurrentHp()}";
    }
    public void UpdateBiomsText(string value)
    {
        biomsText.text = value;
    }
    void OnDestroy()
    {
        coinManager.OnCoinsChanged -= UpdateCoins;
        playerStats.OnHpChanged -= UpdatePlayerHp;
        stock.OnAddToStock -= HandleAddToStock;
        stock.OnRemoveFromStock -= HandleRemoveFromStock;
        stock.OnSetCurrentMonster -= HandleSetCurrentMonster;
        battleSystem.OnBattleStarted -= HandleBattleStarted;
        battleSystem.OnBattleEnded -= HandleEndOfBattle;
        biomManager.OnCurrentBiomChange -= HandleBiomChange;
    }
}