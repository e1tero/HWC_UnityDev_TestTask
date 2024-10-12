using UnityEngine;

[CreateAssetMenu(fileName = "BarrierAbilityData", menuName = "Abilities/Barrier")]
public class BarrierAbilityData : ScriptableObject
{
    [SerializeField] private int _shieldAmount;
    [SerializeField] private int _duration;
    [SerializeField] private int _cooldown;

    public int ShieldAmount => _shieldAmount;
    public int Duration => _duration;
    public int Cooldown => _cooldown;
}