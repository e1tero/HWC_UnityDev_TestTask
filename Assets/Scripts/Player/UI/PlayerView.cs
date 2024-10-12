using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerView
{
    private HealthBar _healthBar;
    private AbilityUI[] _abilityButtons;
    private GameObject _statusEffects;

    private GameObject _statusEffectPrefab;
    
    private EffectIconsStorage _effectIconsStorage;
    
    private List<GameObject> _activeEffectIcons = new List<GameObject>();

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
            Object.Destroy(icon);
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
        if (effect is BurningEffect)
        {
            return _effectIconsStorage.burningIcon;
        }
        if (effect is RegenerationEffect)
        {
            return _effectIconsStorage.regenerationIcon;
        }
        if (effect is ShieldEffect)
        {
            return _effectIconsStorage.shieldIcon;
        }
        return null;
    }
}
