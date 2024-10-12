public class BarrierAbility : IAbility
{
    private BarrierAbilityData _abilityData;
    private int _currentCooldown;

    public BarrierAbility(BarrierAbilityData abilityData)
    {
        _abilityData = abilityData;
        _currentCooldown = 0;
    }
    public void Apply(Unit caster, Unit target)
    {
        var shieldEffect = new ShieldEffect(_abilityData.ShieldAmount, _abilityData.Duration);
        caster.ApplyEffect(shieldEffect);
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

    public string GetName() => "Barrier"; 

    public int GetCooldown() => _currentCooldown;

    public TargetType GetTargetType() => TargetType.Self;
}