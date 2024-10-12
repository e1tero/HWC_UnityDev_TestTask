public class RegenerationEffect : Effect
{
    private readonly int _healPerTurn;

    public RegenerationEffect(int healPerTurn, int duration) : base(duration)
    {
        _healPerTurn = healPerTurn;
    }

    public override void ApplyEffect(Unit target)
    {
        target.Heal(_healPerTurn);
    }

    public override void TickEffect(Unit target)
    {
        base.TickEffect(target);
        if (!IsActive())
        {
            target.RemoveEffect<RegenerationEffect>(); 
        }
    }
}