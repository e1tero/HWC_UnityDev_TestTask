public interface IAbility
{
    void Apply(Unit caster, Unit target); 
    bool IsOnCooldown();
    void TickCooldown();
    void ResetCooldown();
    int GetCooldown();
    string GetName();
    TargetType GetTargetType(); 
}

public enum TargetType
{
    Self,   
    Enemy    
}