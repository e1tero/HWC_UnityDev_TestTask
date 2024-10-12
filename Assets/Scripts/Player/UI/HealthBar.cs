using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar
{
    private Slider _slider;
    private TMP_Text _healthText; 

    public HealthBar(Slider slider, TMP_Text healthText, int maxHealth)
    {
        _slider = slider;
        _healthText = healthText; 

        _slider.minValue = 0;
        _slider.maxValue = maxHealth;
        
        SetMaxHealth(maxHealth);
    }

    public void SetHealth(int health)
    {
        if (_slider.value != health)
        {
            _slider.value = Mathf.Clamp(health, _slider.minValue, _slider.maxValue);
        }
        
        UpdateHealthText(health);
    }

    private void SetMaxHealth(int maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = maxHealth;
        
        UpdateHealthText(maxHealth);
    }

    private void UpdateHealthText(int health)
    {
        if (_healthText != null)
        {
            _healthText.text = $"{health}/{_slider.maxValue}";
        }
    }
}