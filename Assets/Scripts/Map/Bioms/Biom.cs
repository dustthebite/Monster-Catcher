using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class Biom : MonoBehaviour, IBiom
{
    [Inject] IBattleSystem battleSystem;
    [Inject] IPlayerStock playerStock;
    [Inject] IBiomManager biomManager;
    [SerializeField] Elements element;
    [SerializeField] string biomeName;
    [SerializeField] float randomEncountersTiming = 30f;
    [SerializeField] List<MonsterBase> habitantsBases;
    List<Monster> habitants;
    IMonsterFactory monsterFactory;
    IRandomEncounterFactory randomEncounterFactory;
    public Elements GetBiomeElement() => element;
    public string GetBiomeName() => biomeName;
    bool randomEncountersEnabled;
    float timeSinceLastRandomEncounter = 0f;

    void Start()
    {
        battleSystem.OnBattleStarted += HandleBattleStart;
        battleSystem.OnBattleEnded += HandleBattleEnd;
        monsterFactory = new MonsterFactory();
        randomEncounterFactory = new RandomEncounterFactory(battleSystem);
        randomEncountersEnabled = false;
    }
    void HandleBattleEnd()
    {
        randomEncountersEnabled = true;
        timeSinceLastRandomEncounter = 0f;
    }
    void HandleBattleStart()
    {
        randomEncountersEnabled = false;
        timeSinceLastRandomEncounter = 0f;
    }
    void Update() 
    {
        if(randomEncountersEnabled && biomManager.AreEncountersAllowed() && biomManager.GetCurrentBiom() == this)
        {
            if(!battleSystem.IsBattleGoing() && timeSinceLastRandomEncounter >= randomEncountersTiming && habitantsBases.Count > 0 )
            {
                randomEncounterFactory.CreateRandomEncounter(playerStock.GetCurrentMonster(), monsterFactory.CreateMonster(UnityEngine.Random.Range(50, 250), habitantsBases[UnityEngine.Random.Range(0,5)]))
                .StartEncounter();
                timeSinceLastRandomEncounter = 0f;
            }
            else
            timeSinceLastRandomEncounter++; 
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        biomManager.SetCurrentBiom(this);
        randomEncountersEnabled = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        randomEncountersEnabled = false;
        timeSinceLastRandomEncounter = 0f;
    }
    void OnDestroy()
    {
        battleSystem.OnBattleStarted -= HandleBattleStart;
        battleSystem.OnBattleEnded -= HandleBattleEnd;
    }
}
