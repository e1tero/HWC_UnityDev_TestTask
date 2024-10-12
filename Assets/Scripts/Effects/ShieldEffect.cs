public class ShieldEffect : Effect
{
    private int _shieldAmount;

    public ShieldEffect(int shieldAmount, int duration) : base(duration)
    {
        _shieldAmount = shieldAmount;
    }

    public override void ApplyEffect(Unit target)
    {
        target.ApplyShield(_shieldAmount);
    }

    public override void TickEffect(Unit target)
    {
        base.TickEffect(target);
        if (!IsActive())
        {
            target.RemoveEffect<ShieldEffect>();
        }
    }
}