using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.UI;
public class PlayerInBattle : MonoBehaviour, IPlayerInBattle
{
    IBattleSystem battleSystem;
    Player controller;
    IPlayerStock stock;
    [Inject]
    public void Construct(IBattleSystem _battleSystem, Player _controller, IPlayerStock _stock)
    {
        battleSystem = _battleSystem;
        controller = _controller;
        stock = _stock;
    }
    Monster player;
    bool isPlayerInBattle;
    public bool IsPlayerInBattle() => isPlayerInBattle;
    bool canPlayerMove;
    public string FirstAbilityName() => player.GetFirstLevelAbilityName();
    public string SecondLevelAbilityName() => player.GetSecondLevelAbilityName();
    public string ThirdLevelAbilityName() => player.GetThirdLevelAbilityName();
    void Start() 
    {
        canPlayerMove = false;

        controller.Battle.UseFirstAbility.performed += ctx => CastFirstAbility();
        controller.Battle.UseSecondAbility.performed += ctx => CastSecondAbility();
        controller.Battle.UseThirdAbility.performed += ctx => CastThirdAbility();
        controller.Battle.PhysicalAttack.performed += ctx => PhysicalAttack();

        /*
        battleSystem.OnTurnPassToEnemy += PhysicalAttack;
        battleSystem.OnTurnPassToEnemy += CastFirstAbility;
        battleSystem.OnTurnPassToEnemy += CastSecondAbility;
        battleSystem.OnTurnPassToEnemy += CastThirdAbility;*/
    }
    void OnDestroy()
    {
        controller.Battle.UseFirstAbility.performed -= ctx => CastFirstAbility();
        controller.Battle.UseSecondAbility.performed -= ctx => CastSecondAbility();
        controller.Battle.UseThirdAbility.performed -= ctx => CastThirdAbility();
        controller.Battle.PhysicalAttack.performed -= ctx => PhysicalAttack();
        /*
        battleSystem.OnTurnPassToEnemy -= PhysicalAttack;
        battleSystem.OnTurnPassToEnemy -= CastFirstAbility;
        battleSystem.OnTurnPassToEnemy -= CastSecondAbility;
        battleSystem.OnTurnPassToEnemy -= CastThirdAbility;*/
    }
    void Update()
    {
        player = battleSystem.GetPlayerMonster();
        if(battleSystem.GetTurn() == Turn.Player)
        {
            canPlayerMove = true;
        }
    }
    public void PhysicalAttack()
    {
        if(canPlayerMove){
            Debug.Log("PlayerInBattle : PhysicalAttack");
            player.GetTarget().TakeDamage(player.GetAttackDamage());
            battleSystem.PassTurnToEnemy();
        }
        else
        Debug.Log("Not player`s turn");
    } 
    public void CastFirstAbility()
    {
        if(canPlayerMove){
            player.CastFirstAbility();
            battleSystem.PassTurnToEnemy();
        }
        else
        Debug.Log("Not player`s turn");
    }
    public void CastSecondAbility()
    {
        if(canPlayerMove){
            if(player.GetCurrentSp() >= player.GetSecondAbilityCost() && player.GetCurrentExp() >= player.GetExpNeedeForSecondLevelAbility()){
                player.CastSecondAbility();
                battleSystem.PassTurnToEnemy();
            }
            else
            Debug.Log("Player in Battle : not enough exp or sp to cast second level ability");
        }
        else
        Debug.Log("Not player`s turn");
    }
    public void CastThirdAbility()
    {
        if(canPlayerMove){
            if(player.GetCurrentSp() >= player.GetThirdAbilityCost() && player.GetCurrentExp() >= player.GetExpNeedeForThirdLevelAbility()){
                player.CastThirdAbility();
                battleSystem.PassTurnToEnemy();
            }
            else
            Debug.Log("Player in Battle : not enough exp or sp to cast third level ability");
        }
        else
        Debug.Log("Not player`s turn");
    }
}