public class RegenerationAbility : IAbility
{
    private int _currentCooldown;
    private RegenerationAbilityData _abilityData;

    public RegenerationAbility(RegenerationAbilityData abilityData)
    {
        _abilityData = abilityData;
        _currentCooldown = 0;
    }
    public void Apply(Unit caster, Unit target)
    {
        var regenerationEffect = new RegenerationEffect(_abilityData.HealingPerTurn, _abilityData.Duration); 
        caster.ApplyEffect(regenerationEffect);
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

    public string GetName() => "Regeneration"; 

    public int GetCooldown() => _currentCooldown;

    public TargetType GetTargetType() => TargetType.Self;
}