using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IBattleSystem
{
    public void StartBattle(Monster player, Monster enemy);
    public void EndBattle();
    public Turn GetTurn();
    public Monster GetPlayerMonster();
    public Monster GetEnemyMonster();
    public event Action OnBattleStarted;
    public event Action OnBattleEnded;
    public event Action OnRun;
    public event Action OnTurnPassToPlayer;
    public event Action OnTurnPassToEnemy;
    public void PassTurnToPlayer();
    public void PassTurnToEnemy();
    public int GetTurnNumber();
    public bool IsBattleGoing();
    public void Run();
    public string LogInfo();
}
