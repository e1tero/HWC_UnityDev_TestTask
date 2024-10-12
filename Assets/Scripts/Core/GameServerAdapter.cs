using UnityEngine;

public class GameServerAdapter : IGameServer
{
    private IPlayerController _playerController;
    private IPlayerController _opponentController;

    public void ApplyAbility(IPlayerController source, IPlayerController target, IAbility ability)
    {
        var targetUnit = ability.GetTargetType() == TargetType.Self ? source.GetUnit() : target.GetUnit();
        
        ability.Apply(source.GetUnit(), targetUnit);
        
        Debug.Log($"Способность {ability.GetName()} успешно применена.");
        
        source.UpdateView();
        target.UpdateView();
    }

    public void RestartGame()
    {
        if (_playerController == null || _opponentController == null)
        {
            Debug.LogError("PlayerController или OpponentController не инициализированы!");
            return;
        }

        _playerController.GetUnit().ResetUnit();
        _opponentController.GetUnit().ResetUnit();

        _playerController.UpdateView();
        _opponentController.UpdateView();
    }

    public void InitializeControllers(IPlayerController playerController, IPlayerController opponentController)
    {
        _playerController = playerController;
        _opponentController = opponentController;
    }
}