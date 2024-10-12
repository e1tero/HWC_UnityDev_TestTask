using UnityEngine;

public class SceneInstaller : MonoBehaviour
{
    [SerializeField] private PlayerSetup playerSetup;  
    [SerializeField] private PlayerSetup aiSetup;     
    [SerializeField] private BattleManager battleManager;

    private void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
        if (battleManager == null)
        {
            Debug.LogError("BattleManager не найден на сцене!");
            return;  
        }
        
        if (playerSetup == null)
        {
            Debug.LogError("PlayerSetup для реального игрока не установлен!");
            return;
        }

        if (aiSetup == null)
        {
            Debug.LogError("PlayerSetup для AI не установлен!");
            return;
        }
        
        battleManager.StartBattle(playerSetup.GetPlayerController(), aiSetup.GetPlayerController());
    }
}