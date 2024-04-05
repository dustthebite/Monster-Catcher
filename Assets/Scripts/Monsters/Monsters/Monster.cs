using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Monster : IMonster, IDamageable, IStatusAffected
{
    public Monster(int _exp, MonsterBase _baseStats)
    {
        exp = _exp;
        abilityManager = new AbilityManager();
        baseStats = _baseStats;
        currentHp = baseStats.maxHp;
        currentSp = baseStats.maxSp;
        statusEffects = new List<IStatusEffect>();
    }
    public Monster(Monster prototype)
    {
        exp = prototype.GetCurrentExp();
        abilityManager = new AbilityManager();
        baseStats = prototype.GetBaseStats();
        currentHp = baseStats.maxHp;
        currentSp = baseStats.maxSp;
        statusEffects = new List<IStatusEffect>();
    }
    public Monster(MonsterBase _baseStats, int _hp, int _sp, int _exp)
    {
        exp = _exp;
        abilityManager = new AbilityManager();
        baseStats = _baseStats;
        currentHp = _hp;
        currentSp = _sp;
        statusEffects = new List<IStatusEffect>();
    }
    protected IAbilityManager abilityManager;
    protected MonsterBase baseStats;
    protected List<IStatusEffect> statusEffects;
    public List<IStatusEffect> GetStatusEffects() => statusEffects;
    
    public void AddStatusEffect(IStatusEffect _statusEffect)
    {
        bool isReplased = false;
        foreach (var eff in new List<IStatusEffect>(statusEffects)) 
        {
            if(_statusEffect.GetStatusEffectType() == eff.GetStatusEffectType())
            {
                statusEffects.Remove(eff);
                statusEffects.Add(_statusEffect);
                isReplased = true;
            }
        }
        if(!isReplased)
        statusEffects.Add(_statusEffect);

    }
    public void RemoveStatusEffect(IStatusEffect _statusEffect)
    {
        statusEffects.Remove(_statusEffect);
    }
    public void CheckOnStatusEffects()
    {
        List<IStatusEffect> effectsToRemove = new List<IStatusEffect>();

        foreach (var statusEffect in new List<IStatusEffect>(statusEffects))
        {
            if (statusEffect.GetLifeSpan() <= 0)
            {
                effectsToRemove.Add(statusEffect);
            }
            else
            {
                statusEffect.TriggerEffect();
            }
        }

        foreach (var effectToRemove in effectsToRemove)
        {
            RemoveStatusEffect(effectToRemove);
        }
    }
    public void NullifyStatusEffects()
    {
        statusEffects = new List<IStatusEffect>();
    }
    protected Monster target;
    protected int currentHp;
    protected int currentSp;
    protected int damageReduction = 0;
    protected int exp = 0;
    public Sprite GetSprite() => baseStats.sprite;
    public MonsterType GetMonsterType() => baseStats.type;
    public Elements GetElement() => baseStats.element;
    public string GetDescription() => baseStats.description;
    public int GetCurrentHp() => currentHp;
    public int DamageReduction() => damageReduction;
    public int GetCurrentSp() => currentSp;
    public void RestoreFullSp() => currentSp = baseStats.maxSp;
    public void AddSp(int sp) => currentSp += sp;
    public int GetAttackDamage() => baseStats.attackDamage;
    public Monster GetTarget() => target;
    public MonsterBase GetBaseStats() => baseStats;
    public void SetTarget(Monster _target) => target = _target;
    public int GetExpNeedeForSecondLevelAbility() => baseStats.expNeededForSecondLevelAbility;
    public int GetExpNeedeForThirdLevelAbility() => baseStats.expNeededForThirdLevelAbility;
    public string GetFirstLevelAbilityName() => baseStats.firstLevelAbilityName;
    public string GetSecondLevelAbilityName() => baseStats.secondLevelAbilityName;
    public string GetThirdLevelAbilityName() => baseStats.thirdLevelAbilityName;
    public void TakeDamage(int damage)
    {
        damage -= damageReduction;
        currentHp -= damage;
        if(currentHp <= 0)
        Die();
    }
    public void Die()
    {
        Debug.Log($"Insert death logic of monster");
    }
    public void RestoreHp(int hp)
    {
        currentHp += hp;
        if(currentHp > baseStats.maxHp)
        {
            Debug.Log("currentHp > baseStats.maxHp");
            RestoreFullHp();
        }
    }
    public void RestoreFullHp() => currentHp = baseStats.maxHp;

    public int GetCurrentExp() => exp;
    public void AddExp(int _exp) => exp += _exp;
    public int GetDamageReduction() => damageReduction;
    public void SetDamageReduction(int _damageReduction) => damageReduction = _damageReduction;
    public void NullifyDamageReduction() => damageReduction = 0;
    public int GetFirstAbilityCost() => baseStats.firstLevelAbilityCost;
    public int GetSecondAbilityCost() => baseStats.secondLevelAbilityCost;
    public int GetThirdAbilityCost() => baseStats.thirdLevelAbilityCost;
    public void CastFirstAbility()
    {
        int cost = baseStats.firstLevelAbilityCost;
        
        if(currentSp >= cost){
            abilityManager.UseAbility(baseStats.firstLevelAbilityName, this);
            currentSp -= cost;
        }
        else
        Debug.Log("Not enough SP to cast first ability");
    }

    public void CastSecondAbility()
    {
        if(exp >= baseStats.expNeededForSecondLevelAbility){
        int cost = baseStats.secondLevelAbilityCost;
        if(currentSp >= cost){
            abilityManager.UseAbility(baseStats.secondLevelAbilityName, this);
            currentSp -= cost;
        }
        else
        Debug.Log("Not enough SP to cast second ability");
        }
        else
        Debug.Log("Need more EXP to cast second ability");
    }
    public void CastThirdAbility()
    {
        if(exp >= baseStats.expNeededForThirdLevelAbility){
        int cost = baseStats.thirdLevelAbilityCost;
        if(currentSp >= cost){
            abilityManager.UseAbility(baseStats.thirdLevelAbilityName, this);
            currentSp -= cost;
        }
        else
        Debug.Log("Not enough SP to cast third ability");
        }
        else
        Debug.Log("Need more EXP to cast third ability");
    }
}