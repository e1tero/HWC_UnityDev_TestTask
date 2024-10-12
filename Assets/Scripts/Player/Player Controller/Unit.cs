using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public int Health { get; private set; }
    private int _shieldAmount;
    private List<IAbility> _abilities;
    private List<Effect> _activeEffects;

    public Unit(int initialHealth, List<IAbility> abilities)
    {
        Health = initialHealth;
        _abilities = abilities;
        _activeEffects = new List<Effect>();
        _shieldAmount = 0;
    }

    public void TakeDamage(int amount)
    {
        if (_shieldAmount > 0)
        {
            int damageToShield = Mathf.Min(amount, _shieldAmount);
            _shieldAmount -= damageToShield;
            amount -= damageToShield;
        }

        if (amount > 0)
        {
            Health = Mathf.Max(Health - amount, 0);
        }
    }

    public void Heal(int amount)
    {
        Health = Mathf.Min(Health + amount, 100);
    }

    public void ApplyShield(int shieldAmount)
    {
        _shieldAmount += shieldAmount;
    }

    public void RemoveEffect<T>() where T : Effect
    {
        _activeEffects.RemoveAll(effect => effect is T);
    }

    public void ApplyEffect(Effect effect)
    {
        _activeEffects.Add(effect);
    }

    public void TickEffects()
    {
        foreach (var effect in _activeEffects.ToArray())
        {
            effect.ApplyEffect(this); 
            effect.TickEffect(this); 

            if (!effect.IsActive())
            {
                _activeEffects.Remove(effect);
            }
        }
    }

    public List<IAbility> GetAbilities() => _abilities;

    public List<Effect> GetActiveEffects() => _activeEffects;
    
    public void TickAbilitiesCooldowns()
    {
        foreach (var ability in _abilities)
        {
            ability.TickCooldown();
        }
    }
}