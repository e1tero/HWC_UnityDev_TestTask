public class Effect
{
    public int Duration { get; set; }

    public Effect(int duration)
    {
        Duration = duration;
    }
    
    public virtual void ApplyEffect(Unit target)
    {
    }
    
    public virtual void TickEffect(Unit target)
    {
        Duration--;
    }
    
    public bool IsActive()
    {
        return Duration > 0;
    }
}