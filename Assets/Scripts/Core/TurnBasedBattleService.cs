using System;
using System.Threading.Tasks;

public class TurnBasedBattleService
{
    private IPlayerController _playerController;
    private IPlayerController _opponentController;
    private BattleLogService _battleLogService;
    private bool _roundCompleted;

    public TurnBasedBattleService(IPlayerController playerController, IPlayerController opponentController, BattleLogService battleLogService)
    {
        _playerController = playerController;
        _opponentController = opponentController;
        _battleLogService = battleLogService;

        _playerController.PlayerInput.OnAbilitySelected += OnPlayerAbilitySelected;
        _opponentController.PlayerInput.OnAbilitySelected += OnOpponentAbilitySelected;

        DelayExecution(StartPlayerTurn, 1000);
    }

    private void StartPlayerTurn()
    {
        _roundCompleted = false;
        _playerController.EnableInput();
        _battleLogService.Log("Ход игрока начался.");

        _playerController.UpdateView();
        _opponentController.UpdateView();
    }

    private void OnPlayerAbilitySelected(int abilityIndex)
    {
        _playerController.DisableInput();

        var selectedAbility = _playerController.GetUnit().GetAbilities()[abilityIndex];
        ExecuteTurn(selectedAbility, _playerController, _opponentController);

        _battleLogService.LogPlayerAbility("Игрок", selectedAbility.GetName());

        DelayExecution(ExecuteOpponentTurn, 1000);
    }

    private void ExecuteTurn(IAbility ability, IPlayerController source, IPlayerController target)
    {
        Unit targetUnit = ability.GetTargetType() == TargetType.Self ? source.GetUnit() : target.GetUnit();
        ability.Apply(source.GetUnit(), targetUnit);

        source.UpdateView();
        target.UpdateView();
    }

    private void ExecuteOpponentTurn()
    {
        _battleLogService.Log("Ход ИИ начался.");

        _opponentController.PlayerInput.EnableInput();
        _opponentController.UpdateView();
    }

    private void OnOpponentAbilitySelected(int abilityIndex)
    {
        _opponentController.DisableInput();

        var selectedAbility = _opponentController.GetUnit().GetAbilities()[abilityIndex];
        ExecuteTurn(selectedAbility, _opponentController, _playerController);

        _battleLogService.LogAIAbility(selectedAbility.GetName());

        _playerController.UpdateView();
        _opponentController.UpdateView();
        
        if (!_roundCompleted)
        {
            TickEffectsAndCooldowns();
            _roundCompleted = true;
        }

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


