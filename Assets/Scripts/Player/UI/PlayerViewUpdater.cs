using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerViewUpdater
{
    private PlayerView _playerView;
    private Button[] _abilityButtons;
    private TMP_Text[] _cooldownTexts;
    private Unit _player;
    
    public PlayerViewUpdater(PlayerView playerView, Button[] abilityButtons, TMP_Text[] cooldownTexts, Unit player)
    {
        _playerView = playerView;
        _abilityButtons = abilityButtons;
        _cooldownTexts = cooldownTexts;
        _player = player;
    }

    public void UpdateUI(bool isPlayerTurn)
    {
        _playerView.UpdateHealth(_player.Health);
        _playerView.UpdateStatusEffects(_player.GetActiveEffects());
        _playerView.UpdateAbilities(_player.GetAbilities());

        for (int i = 0; i < _player.GetAbilities().Count; i++)
        {
            var ability = _player.GetAbilities()[i];

            if (ability.IsOnCooldown())
            {
                _abilityButtons[i].interactable = false;
                _cooldownTexts[i].text = ability.GetCooldown().ToString();
            }
            else
            {
                _abilityButtons[i].interactable = isPlayerTurn;
                _cooldownTexts[i].text = "";
            }
        }
    }
}