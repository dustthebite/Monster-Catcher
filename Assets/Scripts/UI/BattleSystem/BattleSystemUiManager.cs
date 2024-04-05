using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;
public class BattleSystemUiManager : MonoBehaviour, IBattleSystemUiManager
{
    [Inject] IPlayerInBattle playerInBattle;
    [Inject] IBattleSystem battleSystem;
    [Inject] IItemManager itemManager;
    [Header("Camera")]
    [SerializeField] Camera battleCamera;
    [Header("Usual text")]
    [SerializeField] TextMeshProUGUI playerHPText;
    [SerializeField] TextMeshProUGUI enemyHPText;
    [SerializeField] TextMeshProUGUI playerSPText;
    [SerializeField] TextMeshProUGUI enemySPText;
    [SerializeField] TextMeshProUGUI playerEXPText;
    [SerializeField] TextMeshProUGUI enemyEXPText;
    [SerializeField] TextMeshProUGUI logText;
    [Header("Abilitys buttons")]
    [SerializeField] Button physicalAttackButton;
    [SerializeField] Button firstLevelAbilityButton;
    [SerializeField] Button secondLevelAbilityButton;
    [SerializeField] Button thirdLevelAbilityButton;
    [Header("Items buttons")]
    [SerializeField] Button smokeBombButton;
    [SerializeField] Button tamingCrystalButton;
    [SerializeField] Button hpPotionButton;
    [SerializeField] Button spPotionButton;
    [SerializeField] Button universalPotionButton;
    [Header("Buttons text")]
    [SerializeField] TextMeshProUGUI physicalAttackButton_Text;
    [SerializeField] TextMeshProUGUI firstLevelAbilityButton_Text;
    [SerializeField] TextMeshProUGUI secondLevelAbilityButton_Text;
    [SerializeField] TextMeshProUGUI thirdLevelAbilityButton_Text;
    [Header("Sprites")]
    [SerializeField] Image playerSprite;
    [SerializeField] Image enemySprite;

    GameObject mainCameraObject;
    GameObject battleCameraObject;

    void Start()
    {
        battleSystem.OnBattleStarted += StartBattle;
        battleSystem.OnBattleEnded += EndBattle;
        battleSystem.OnTurnPassToEnemy += PassTurn;
        battleSystem.OnTurnPassToPlayer += PassTurn;
        mainCameraObject = Camera.main.gameObject;
        battleCameraObject = battleCamera.gameObject;

        physicalAttackButton.onClick.AddListener(playerInBattle.PhysicalAttack);
        firstLevelAbilityButton.onClick.AddListener(playerInBattle.CastFirstAbility);
        secondLevelAbilityButton.onClick.AddListener(playerInBattle.CastSecondAbility);
        thirdLevelAbilityButton.onClick.AddListener(playerInBattle.CastThirdAbility);

        smokeBombButton.onClick.AddListener(itemManager.UseSmokebomb);
        tamingCrystalButton.onClick.AddListener(itemManager.UseTamingCrystal);
        hpPotionButton.onClick.AddListener(itemManager.UseHpPotion);
        spPotionButton.onClick.AddListener(itemManager.UseSpPotion);
        universalPotionButton.onClick.AddListener(itemManager.UseUniversalPotion);


    }
    public void StartBattle()
    {
        mainCameraObject.SetActive(false);
        battleCameraObject.SetActive(true);

        playerSprite.sprite = battleSystem.GetPlayerMonster().GetSprite();
        enemySprite.sprite = battleSystem.GetEnemyMonster().GetSprite();

        firstLevelAbilityButton_Text.text = battleSystem.GetPlayerMonster().GetFirstLevelAbilityName();
        secondLevelAbilityButton_Text.text = battleSystem.GetPlayerMonster().GetSecondLevelAbilityName();
        thirdLevelAbilityButton_Text.text = battleSystem.GetPlayerMonster().GetThirdLevelAbilityName();

        UpdateTexts();
    }

    void UpdateTexts()
    {
        playerHPText.text ="HP :" + battleSystem.GetPlayerMonster().GetCurrentHp().ToString();
        enemyHPText.text = "HP :" + battleSystem.GetEnemyMonster().GetCurrentHp().ToString();
        playerSPText.text = "SP :" + battleSystem.GetPlayerMonster().GetCurrentSp().ToString();
        enemySPText.text = "SP :" + battleSystem.GetEnemyMonster().GetCurrentSp().ToString();
        playerEXPText.text = "EXP :" + battleSystem.GetPlayerMonster().GetCurrentExp().ToString();
        enemyEXPText.text = "EXP :" + battleSystem.GetEnemyMonster().GetCurrentExp().ToString();

        if(logText.text != string.Empty)
        logText.text = "Enemy used " + battleSystem.LogInfo();
    }

    public void EndBattle()
    {
        mainCameraObject.SetActive(true);
        battleCameraObject.SetActive(false);
        logText.text = string.Empty;
    }
    public void PassTurn()
    {
        UpdateTexts();
        
    }


    void OnDestroy()
    {
        battleSystem.OnBattleStarted -= StartBattle;
        battleSystem.OnBattleEnded -= EndBattle;
        battleSystem.OnTurnPassToEnemy -= PassTurn;
        battleSystem.OnTurnPassToPlayer -= PassTurn;
    }
}