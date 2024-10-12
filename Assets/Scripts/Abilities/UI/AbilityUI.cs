using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI
{
    private Button _button;
    private TMP_Text _cooldownText;
    private TMP_Text _abilityNameText;

    public AbilityUI(Button button, TMP_Text cooldownText, TMP_Text abilityNameText)
    {
        _button = button;
        _cooldownText = cooldownText;
        _abilityNameText = abilityNameText;
    }

    public void SetAbility(IAbility ability)
    {
        _abilityNameText.text = ability.GetName();
        SetCooldown(ability.IsOnCooldown() ? ability.GetCooldown() : 0);
    }

    private void SetCooldown(int cooldown)
    {
        _cooldownText.text = cooldown > 0 ? cooldown.ToString() : "";
        _button.interactable = cooldown == 0;
    }

    public void Enable()
    {
        _button.interactable = true;
    }

    public void Disable()
    {
        _button.interactable = false;
    }
}