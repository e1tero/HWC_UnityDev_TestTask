using TMPro;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text logText; 
    private TurnBasedBattleService _battleService;
    private IGameServer _gameServer;
    private BattleLogService _battleLogService;

    public void StartBattle(PlayerController playerController, PlayerController aiController)
    {
        _gameServer = new GameServerAdapter();
        _gameServer.InitializeControllers(playerController, aiController);  
        
        _battleLogService = new BattleLogService(logText);
        
        _battleService = new TurnBasedBattleService(playerController, aiController, _gameServer, _battleLogService);
    }

    public void RestartBattle()
    {
        if (_gameServer != null)
        {
            _gameServer.RestartGame();
            Debug.Log("Бой перезапущен.");
        }
        else
        {
            Debug.LogError("GameServer не инициализирован для перезапуска боя!");
        }
    }
}