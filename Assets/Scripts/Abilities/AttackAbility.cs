public class AttackAbility : IAbility
{
    private AttackAbilityData _abilityData;

    public AttackAbility(AttackAbilityData abilityData)
    {
        _abilityData = abilityData;
    }
    public void Apply(Unit caster, Unit target)
    {
        target.TakeDamage(_abilityData.Damage); 
    }

    public bool IsOnCooldown() => false; 

    public void TickCooldown() { }

    public void ResetCooldown() { }

    public string GetName() => "Attack"; 

    public int GetCooldown() => 0;

    public TargetType GetTargetType() => TargetType.Enemy; 
}