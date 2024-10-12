using UnityEngine;

[CreateAssetMenu(fileName = "FireballAbilityData", menuName = "Abilities/Fireball")]
public class FireballAbilityData : ScriptableObject
{
    [SerializeField] private int _damage = 5;
    [SerializeField] private int _burnDuration = 5;
    [SerializeField] private int _burnDamage = 1;
    [SerializeField] private int _cooldown = 6;

    public int Damage => _damage;
    public int BurnDuration => _burnDuration;
    public int BurnDamage => _burnDamage;
    public int Cooldown => _cooldown;
}
