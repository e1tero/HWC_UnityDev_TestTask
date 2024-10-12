using UnityEngine;

public class FireballAbility : IAbility
{
    private int _currentCooldown;
    private FireballAbilityData _abilityData;

    public FireballAbility(FireballAbilityData abilityData)
    {
        _abilityData = abilityData;
        _currentCooldown = 0;
    }

    public void Apply(Unit caster, Unit target)
    {
        target.TakeDamage(_abilityData.Damage); 
        target.ApplyEffect(new BurningEffect(_abilityData.BurnDamage, _abilityData.BurnDuration));
        _currentCooldown = _abilityData.Cooldown;
    }

    public bool IsOnCooldown() => _currentCooldown > 0;

    public void TickCooldown()
    {
        if (_currentCooldown > 0)
        {
            _currentCooldown--;
        }
    }

    public void ResetCooldown()
    {
        _currentCooldown = 0;
    }

    public string GetName() => "Fireball";

    public int GetCooldown() => _currentCooldown;

    public TargetType GetTargetType() => TargetType.Enemy;
}