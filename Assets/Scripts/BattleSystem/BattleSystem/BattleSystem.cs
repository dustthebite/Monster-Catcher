using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
public class BattleSystem : MonoBehaviour, IBattleSystem
{
    [Inject] ICoinManager coinManager;
    [Inject] IPlayerStock stock;
    [SerializeField] PlayerStats playerStats;
    int turnNumber;
    public int GetTurnNumber() => turnNumber;
    EnemyTurnLogic enemyTurnLogic;
    bool isBattleGoing;
    public event Action OnBattleStarted;
    public event Action OnBattleEnded;
    public event Action OnRun;
    public event Action OnTurnPassToPlayer;
    public event Action OnTurnPassToEnemy;
    Turn turn;
    Monster player;
    Monster enemy; 
    public bool IsBattleGoing() => isBattleGoing;
    public Monster GetPlayerMonster() => player;
    public Monster GetEnemyMonster() => enemy;
    public string LogInfo() => enemyTurnLogic.GetLastAbilityUsed();
    public void PassTurnToPlayer()
    {
        player.CheckOnStatusEffects();
        turn = Turn.Player;
        turnNumber++;
        OnTurnPassToPlayer?.Invoke();
    }
    public void PassTurnToEnemy()
    {
        enemy.CheckOnStatusEffects();
        turn = Turn.Enemy;
        enemyTurnLogic.ChooseRandomAttack();   
        turnNumber++;
        OnTurnPassToEnemy?.Invoke();
        PassTurnToPlayer();
    }
    void Start()
    {
        isBattleGoing = false;
        turn = Turn.None;
        
        enemyTurnLogic = new EnemyTurnLogic();
    }
    public void StartBattle(Monster _player, Monster _enemy)
    {
        if(_player.GetCurrentHp() <= 0){
        Debug.Log("Monster cant battle!");
        return;
        }

        if(!isBattleGoing){
        turnNumber = 0;
        turn = Turn.Player;
        player = _player;
        enemy = _enemy;
        player.SetTarget(enemy);
        enemyTurnLogic.SetCasterAndTarget(enemy, player);
        isBattleGoing = true;
        OnBattleStarted?.Invoke();
        }
        else
        Debug.Log("Cant start battle");
    }
    public void EndBattle()
    {   if(isBattleGoing){
        turn = Turn.None;
        turnNumber = 0;
        player.NullifyStatusEffects();
        enemy.NullifyStatusEffects();
        isBattleGoing = false;
        OnBattleEnded?.Invoke();
        }
        else
        Debug.Log("Cant end battle");
    }
    public Turn GetTurn() => turn;
    void Update() 
    {
        if(enemy != null && player != null && turn != Turn.None)
        {
            if(enemy.GetCurrentHp() <= 0)
            {
                EndBattle();
                Debug.Log("YOU WIN");
                player.AddExp(100);
                enemy.RestoreFullHp();
                enemy.RestoreFullSp();
                coinManager.AddCoins(100);
            }
            else if (player.GetCurrentHp() <= 0)
            {
                playerStats.TakeDamage(15);
                EndBattle();
                ;
                Debug.Log("YOU LOSE");
                
            }
        }
    }

    public void Run()
    {
        EndBattle();
        OnRun?.Invoke();
    }
}