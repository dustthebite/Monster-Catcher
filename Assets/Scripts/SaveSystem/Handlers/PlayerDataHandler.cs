using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerDataHandler : HandlerAbstraction 
{
    [SerializeField] Transform player;
    [Inject] SaveSystem saveSystem;
    [Inject] IPlayerStock stock;
    [Inject] IPlayerStats stats;
    [Inject] IItemManager itemManager;
    [Inject] ICoinManager coinManager;
    PlayerData data;
    void Start()
    {   
        saveSystem.OnSave += HandleSave;
        saveSystem.OnLoad += HandleLoad;

        HandleLoad();
    }

    protected override void HandleSave()
    {
        data.xPos = player.position.x;
        data.yPos = player.position.y;
        data.hp = stats.GetHp();
        data.coins = coinManager.Coins();
        data.smokeBombs = itemManager.GetSmokebombsAmount();
        data.tamingCrystals = itemManager.GetTamingCrystalsAmount();
        data.hpPotions = itemManager.GetHpPotionsAmount();
        data.spPotions = itemManager.GetSpPotionsAmount();
        data.universalPotions = itemManager.GetUniversalPotionsAmount();
        data.units = new UnitData[stock.GetOccupiedStocksAmount()];

        for(int i = 0; i < data.units.Length; i++)
        {
            Monster monster = stock.GetStock()[i];
            data.units[i] = new UnitData{prefabPath = monster.GetBaseStats().PrefabPath, hp = monster.GetCurrentHp(), sp = monster.GetCurrentSp(), exp = monster.GetCurrentExp()  };
        }

        saveSystem.Save(direcoryName, fileName, data);
    }

    protected override void HandleLoad()
    {
        try{
            data = saveSystem.Load<PlayerData>(direcoryName, fileName);
            player.position = new Vector3(data.xPos, data.yPos);
            stats.SetHp(data.hp);
            coinManager.SetCoins(data.coins);
            itemManager.SetSmokebomb(data.smokeBombs);
            itemManager.SetTamingCrystal(data.tamingCrystals);
            itemManager.SetHpPotion(data.hpPotions);
            itemManager.SetSpPotion(data.spPotions);
            itemManager.SetUniversalPotion(data.universalPotions);

            stock.ResetStock();

            for(int i = 0; i < data.units.Length; i++)
            {
                stock.AddToStocks(new Monster(Resources.Load<MonsterBase>(data.units[i].prefabPath), data.units[i].hp, data.units[i].sp, data.units[i].exp));
            }

            stock.SetCurrentMonster(0);

        }
        catch{
            Debug.Log("Load failed !! ");
        }
    }
}