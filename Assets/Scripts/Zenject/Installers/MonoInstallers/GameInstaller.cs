using UnityEngine;
using Zenject;
public class GameInstaller : MonoInstaller
{
    [SerializeField] SaveSystem saveSystem;
    [SerializeField] PlayerStock playerStock;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerInBattle playerInBattle;
    [SerializeField] BiomManager biomManager;
    [SerializeField] ItemManager itemManager;
    public override void InstallBindings()
    {
        Container.Bind<Player>().ToSelf().AsSingle();
         
        Container.Bind<ICoinManager>().To<CoinManager>().AsSingle();
        
        Container.Bind<SaveSystem>().ToSelf().FromInstance(saveSystem).AsSingle();
        Container.Bind<IPlayerStock>().To<PlayerStock>().FromInstance(playerStock).AsSingle();
        Container.Bind<IBattleSystem>().To<BattleSystem>().FromInstance(battleSystem).AsSingle();
        Container.Bind<IPlayerStats>().To<PlayerStats>().FromInstance(playerStats).AsSingle();
        Container.Bind<IPlayerInBattle>().To<PlayerInBattle>().FromInstance(playerInBattle).AsSingle(); 
        Container.Bind<IBiomManager>().To<BiomManager>().FromInstance(biomManager).AsSingle();
        Container.Bind<IItemManager>().To<ItemManager>().FromInstance(itemManager).AsSingle();
    }
}