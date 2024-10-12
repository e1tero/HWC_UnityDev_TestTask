using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView
{
    private readonly HealthBar _healthBar;
    private readonly AbilityUI[] _abilityButtons;
    private readonly GameObject _statusEffects;
    private readonly GameObject _statusEffectPrefab;

    private readonly EffectIconsStorage _effectIconsStorage;
    private readonly List<GameObject> _activeEffectIcons = new List<GameObject>();

    public PlayerView(HealthBar healthBar, AbilityUI[] abilityButtons, GameObject statusEffects, GameObject statusEffectPrefab, EffectIconsStorage effectIconsStorage)
    {
        _healthBar = healthBar;
        _abilityButtons = abilityButtons;
        _statusEffects = statusEffects;
        _statusEffectPrefab = statusEffectPrefab;
        _effectIconsStorage = effectIconsStorage;
    }

    public void UpdateHealth(int health)
    {
        _healthBar.SetHealth(health);
    }

    public void UpdateStatusEffects(List<Effect> effects)
    {
        foreach (var icon in _activeEffectIcons)
        {
            if (Application.isPlaying)
            {
                Object.Destroy(icon);
            }
            else
            {
                Object.DestroyImmediate(icon);
            }
        }
        _activeEffectIcons.Clear();
        
        foreach (var effect in effects)
        {
            var effectIcon = Object.Instantiate(_statusEffectPrefab, _statusEffects.transform);
            var iconImage = effectIcon.GetComponentInChildren<Image>();
            var counterText = effectIcon.GetComponentInChildren<TMP_Text>();
            
            iconImage.sprite = GetEffectIcon(effect);
            counterText.text = effect.Duration.ToString();

            _activeEffectIcons.Add(effectIcon);
        }
    }

    public void UpdateAbilities(List<IAbility> abilities)
    {
        for (int i = 0; i < abilities.Count; i++)
        {
            _abilityButtons[i].SetAbility(abilities[i]);
        }
    }

    private Sprite GetEffectIcon(Effect effect)
    {
        return effect switch
        {
            BurningEffect => _effectIconsStorage.burningIcon,
            RegenerationEffect => _effectIconsStorage.regenerationIcon,
            ShieldEffect => _effectIconsStorage.shieldIcon,
            _ => null
        };
    }
}
