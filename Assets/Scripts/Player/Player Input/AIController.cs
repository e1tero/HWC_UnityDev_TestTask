using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class AIController : IPlayerInput
{
    public event Action<int> OnAbilitySelected;

    private Unit _aiUnit;
    private Random _random = new Random();

    public AIController(Unit aiUnit)
    {
        _aiUnit = aiUnit;
    }

    private void PerformAITurn()
    {
        var allAbilities = _aiUnit.GetAbilities();

        var availableAbilities = allAbilities.Where(a => !a.IsOnCooldown()).ToList();

        int randomIndex = _random.Next(availableAbilities.Count);
        var selectedAbility = availableAbilities[randomIndex];
        int abilityIndex = allAbilities.IndexOf(selectedAbility);

        OnAbilitySelected?.Invoke(abilityIndex);
    }

    public void EnableInput()
    {
        PerformAITurn();
    }

    public void DisableInput() { }
}

