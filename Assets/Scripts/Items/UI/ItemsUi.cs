using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
public class ItemsUi : MonoBehaviour
{
    [Inject] IItemManager itemManager;

    [Header("Items text")]
    [SerializeField] TextMeshProUGUI tamingCrystalsText;
    [SerializeField] TextMeshProUGUI smokebombsText;
    [SerializeField] TextMeshProUGUI hpPotionsText;
    [SerializeField] TextMeshProUGUI spPotionsText;
    [SerializeField] TextMeshProUGUI universalPotionsText;
    
    void Start()
    {
        itemManager.OnSmokeBombsAmountChanged += UpdateSmokeBombs;
        itemManager.OnTamingCrystalsAmountChanged += UpdateTamingCrystals;
        itemManager.OnHpPotionsAmountChanged += UpdateHpPotions;
        itemManager.OnSpPotionsAmountChanged += UpdateSpPotions;
        itemManager.OnUniversalPotionsAmountChanged += UpdateUniversalPotions;

        UpdateSmokeBombs();
        UpdateTamingCrystals();
        UpdateHpPotions();
        UpdateSpPotions();
        UpdateUniversalPotions();
    }
    void OnDestroy()
    {
        itemManager.OnSmokeBombsAmountChanged -= UpdateSmokeBombs;
        itemManager.OnTamingCrystalsAmountChanged -= UpdateTamingCrystals;
        itemManager.OnHpPotionsAmountChanged -= UpdateHpPotions;
        itemManager.OnSpPotionsAmountChanged -= UpdateSpPotions;
        itemManager.OnUniversalPotionsAmountChanged -= UpdateUniversalPotions;
    }

    void UpdateSmokeBombs()
    {
        smokebombsText.text = "Smokebombs: " + itemManager.GetSmokebombsAmount();
    }
    void UpdateTamingCrystals()
    {
        tamingCrystalsText.text = "Taming crystals: " + itemManager.GetTamingCrystalsAmount();
    }
    void UpdateHpPotions()
    {
        hpPotionsText.text = "Hp potions: " + itemManager.GetHpPotionsAmount();
    }
    void UpdateSpPotions()
    {
        spPotionsText.text = "Sp potions: " + itemManager.GetSpPotionsAmount();
    }
    void UpdateUniversalPotions()
    {
        universalPotionsText.text = "Universal potions: " + itemManager.GetUniversalPotionsAmount();
    }
}