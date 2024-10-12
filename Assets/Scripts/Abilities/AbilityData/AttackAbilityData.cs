using UnityEngine;

[CreateAssetMenu(fileName = "AttackAbilityData", menuName = "Abilities/Attack")]
public class AttackAbilityData : ScriptableObject
{
    [SerializeField] private int _damage;

    public int Damage => _damage;
}