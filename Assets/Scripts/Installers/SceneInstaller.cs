using TMPro;
using UnityEngine;

public class SceneInstaller : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;
    [SerializeField] private PlayerSetup aiSetup;
    [SerializeField] private TMP_Text _logText;

    private TurnBasedBattleService _turnBasedBattleService;

    private void Start()
    {
        var playerController = playerSetup.GetPlayerController();
        var aiController = aiSetup.GetPlayerController();

        var battleLogService = new BattleLogService(_logText);
        _turnBasedBattleService = new TurnBasedBattleService(playerController, aiController,battleLogService);
    }
}