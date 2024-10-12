using System;

public interface IPlayerInput
{
    event Action<int> OnAbilitySelected;
    void EnableInput();
    void DisableInput();
}