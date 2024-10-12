using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AIController : IPlayerInput
{
    public event Action<int> OnAbilitySelected;

    private readonly Unit _aiUnit;
    private readonly Random _random = new();

    public AIController(Unit aiUnit)
    {
        _aiUnit = aiUnit;
    }

    private void PerformAITurn()
    {
        var allAbilities = _aiUnit.GetAbilities();
        
        var availableAbilities = allAbilities.Where(a => !a.IsOnCooldown()).ToList();

        if (availableAbilities.Count == 0)
        {
            Debug.LogWarning("ИИ не нашел доступных способностей, все способности на кулдауне.");
            return;
        }
        
        int randomIndex = _random.Next(availableAbilities.Count);
        var selectedAbility = availableAbilities[randomIndex];
        int abilityIndex = allAbilities.IndexOf(selectedAbility);
        
        Debug.Log($"ИИ выбрал способность: {selectedAbility.GetName()} (Index: {abilityIndex})");
        
        OnAbilitySelected?.Invoke(abilityIndex);
    }

    public void EnableInput()
    {
        PerformAITurn();
    }

    public void DisableInput() { }
}


