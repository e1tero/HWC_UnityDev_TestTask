public class BurningEffect : Effect
{
    private int _damagePerTurn;

    public BurningEffect(int damagePerTurn, int duration) : base(duration)
    {
        _damagePerTurn = damagePerTurn;
    }

    public override void ApplyEffect(Unit target)
    {
        target.TakeDamage(_damagePerTurn);
    }

    public override void TickEffect(Unit target)
    {
        base.TickEffect(target);
        if (!IsActive())
        {
            target.RemoveEffect<BurningEffect>();
        }
    }
}