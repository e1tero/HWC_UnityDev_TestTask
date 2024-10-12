using UnityEngine;

public class PlayerController : IPlayerController
{
    private readonly Unit _player;
    private readonly IPlayerInput _playerInput;
    private readonly PlayerViewUpdater _viewUpdater;
    private bool _isPlayerTurn;

    public IPlayerInput PlayerInput => _playerInput;

    public PlayerController(Unit player, IPlayerInput playerInput, PlayerViewUpdater viewUpdater)
    {
        _player = player;
        _playerInput = playerInput;
        _viewUpdater = viewUpdater;
    }

    public Unit GetUnit()
    {
        return _player;
    }

    public void UpdateView()
    {
        _viewUpdater.UpdateUI(_isPlayerTurn);
    }

    public void EnableInput()
    {
        _isPlayerTurn = true;
        _playerInput.EnableInput();
        UpdateView();
    }

    public void DisableInput()
    {
        _isPlayerTurn = false;
        _playerInput.DisableInput();
        UpdateView();
    }
}