using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Button[] abilityButtons;
    [SerializeField] private TMP_Text[] cooldownTexts;
    [SerializeField] private TMP_Text[] abilityNameTexts;
    [SerializeField] private GameObject statusEffects;

    [Header("Effect Icons")]
    [SerializeField] private GameObject statusEffectPrefab;
    [SerializeField] private EffectIconsStorage effectIconsStorage;

    [Header("Ability Settings")] 
    [SerializeField] private FireballAbilityData _fireballAbilityData;
    [SerializeField] private AttackAbilityData _attackAbilityData;
    [SerializeField] private RegenerationAbilityData _regenerationAbilityData;
    [SerializeField] private BarrierAbilityData _barrierAbilityData;

    [SerializeField] private bool isAi;
    [SerializeField] private int initialHealth;

    private PlayerController _playerController;

    public PlayerController GetPlayerController()
    {
        return _playerController;
    }

    private void Awake()
    {
        var healthBar = new HealthBar(healthSlider,healthText,initialHealth);
        
        var abilitiesUI = new AbilityUI[abilityButtons.Length];
        for (int i = 0; i < abilityButtons.Length; i++)
        {
            abilitiesUI[i] = new AbilityUI(abilityButtons[i], cooldownTexts[i], abilityNameTexts[i]);
        }
        
        var player = new Unit(initialHealth, new List<IAbility>
        {
            new AttackAbility(_attackAbilityData),
            new FireballAbility(_fireballAbilityData),
            new RegenerationAbility(_regenerationAbilityData),
            new BarrierAbility(_barrierAbilityData),
            new CleanseAbility()
        });
        
        var playerView = new PlayerView(healthBar, abilitiesUI, statusEffects, statusEffectPrefab, effectIconsStorage);
        var viewUpdater = new PlayerViewUpdater(playerView, abilityButtons, cooldownTexts, player);
        
        IPlayerInput playerInput;
        if (!isAi)
        {
            playerInput = new PlayerInputController(abilityButtons);
        }
        else
        {
            playerInput = new AIController(player);
        }
        
        _playerController = new PlayerController(player, playerInput, viewUpdater);
    }
}


