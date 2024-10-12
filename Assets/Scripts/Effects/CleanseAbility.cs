public class CleanseAbility : IAbility
{
    private int _cooldown = 5;
    private int _currentCooldown;

    public void Apply(Unit caster, Unit target)
    {
        if (IsOnCooldown()) return;

        caster.RemoveEffect<BurningEffect>();
        _currentCooldown = _cooldown;
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

    public string GetName() => "Cleanse"; 

    public int GetCooldown() => _currentCooldown;

    public TargetType GetTargetType() => TargetType.Self;
}