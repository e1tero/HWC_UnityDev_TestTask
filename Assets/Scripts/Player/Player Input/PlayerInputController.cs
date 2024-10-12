using UnityEngine.UI;

public class PlayerInputController : IPlayerInput
{
    public event System.Action<int> OnAbilitySelected;

    private readonly Button[] _abilityButtons;

    public PlayerInputController(Button[] abilityButtons)
    {
        _abilityButtons = abilityButtons;

        SetupButtons();
    }

    private void SetupButtons()
    {
        for (int i = 0; i < _abilityButtons.Length; i++)
        {
            int index = i;
            _abilityButtons[i].onClick.AddListener(() => OnAbilitySelected?.Invoke(index));
        }
    }

    public void EnableInput()
    {
        foreach (var button in _abilityButtons)
        {
            button.interactable = true; 
        }
    }

    public void DisableInput()
    {
        foreach (var button in _abilityButtons)
        {
            button.interactable = false; 
        }
    }
}