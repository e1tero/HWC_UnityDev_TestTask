using System;
using System.Threading.Tasks;
using UnityEngine;

public sealed class TurnBasedBattleService
{
    private readonly IPlayerController _playerController;
    private readonly IPlayerController _opponentController;
    private readonly IGameServer _gameServer;
    private readonly BattleLogService _battleLogService;
    private bool _roundCompleted;
    private bool _isPlayerTurn;
    private bool _battleInProgress;

    public TurnBasedBattleService(IPlayerController playerController, IPlayerController aiController, IGameServer gameServer, BattleLogService battleLogService)
    {
        _playerController = playerController;
        _opponentController = aiController;
        _gameServer = gameServer;
        _battleLogService = battleLogService;
        
        _playerController.PlayerInput.OnAbilitySelected += OnPlayerAbilitySelected;
        _opponentController.PlayerInput.OnAbilitySelected += OnOpponentAbilitySelected;

        _isPlayerTurn = true;
        _battleInProgress = false;
        
        _playerController.UpdateView();
        _opponentController.UpdateView();
        
        _battleLogService.Log("Игра запущена, ожидание хода игрока.");
        DelayExecution(StartPlayerTurn, 1000);
    }

    private void StartPlayerTurn()
    {
        if (!_isPlayerTurn || _battleInProgress) return;

        _battleInProgress = true;
        _roundCompleted = false;
        
        _battleLogService.Log("Ход игрока начался.");
        _playerController.EnableInput();
        _playerController.UpdateView();
        _opponentController.UpdateView();
    }

    private void OnPlayerAbilitySelected(int abilityIndex)
    {
        if (!_isPlayerTurn || !_battleInProgress) return;

        _playerController.DisableInput();
        var selectedAbility = _playerController.GetUnit().GetAbilities()[abilityIndex];
        _gameServer.ApplyAbility(_playerController, _opponentController, selectedAbility);
        
        _battleLogService.LogPlayerAbility("Игрок", selectedAbility.GetName());

        _isPlayerTurn = false;
        
        DelayExecution(() => _opponentController.PlayerInput.EnableInput(), 1000);
    }

    private void OnOpponentAbilitySelected(int abilityIndex)
    {
        if (_isPlayerTurn) return;

        var selectedAbility = _opponentController.GetUnit().GetAbilities()[abilityIndex];
        _gameServer.ApplyAbility(_opponentController, _playerController, selectedAbility);
        
        _battleLogService.LogAIAbility(selectedAbility.GetName());

        if (!_roundCompleted)
        {
            TickEffectsAndCooldowns();
            _roundCompleted = true;
        }

        _isPlayerTurn = true;
        _battleInProgress = false;
        DelayExecution(StartPlayerTurn, 1000);
    }

    private void TickEffectsAndCooldowns()
    {
        _playerController.GetUnit().TickEffects();
        _opponentController.GetUnit().TickEffects();
        _playerController.GetUnit().TickAbilitiesCooldowns();
        _opponentController.GetUnit().TickAbilitiesCooldowns();
        
        _playerController.UpdateView();
        _opponentController.UpdateView();
        
        _battleLogService.Log("Тик эффектов и перезарядки завершен.");
    }

    private async void DelayExecution(Action action, int delayMilliseconds)
    {
        await Task.Delay(delayMilliseconds);
        action?.Invoke();
    }
}


