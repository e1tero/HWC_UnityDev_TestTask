using UnityEngine;

public class PlayerController : IPlayerController
{
    private Unit _player;
    private IPlayerInput _playerInput;
    private PlayerViewUpdater _viewUpdater;
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