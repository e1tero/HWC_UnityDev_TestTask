using UnityEngine;

[CreateAssetMenu(fileName = "RegenerationAbilityData", menuName = "Abilities/Regeneration")]
public class RegenerationAbilityData : ScriptableObject
{
    [SerializeField] private int _healingPerTurn;
    [SerializeField] private int _duration;
    [SerializeField] private int _cooldown;

    public int HealingPerTurn => _healingPerTurn;
    public int Duration => _duration;
    public int Cooldown => _cooldown;
}