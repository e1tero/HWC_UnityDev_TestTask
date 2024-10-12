using TMPro;

public sealed class BattleLogService
{
    private TMP_Text _logText;
    private int _maxLogLength = 300;

    public BattleLogService(TMP_Text logText)
    {
        _logText = logText;
    }

    public void Log(string message)
    {
        if (_logText != null)
        {
            if (_logText.text.Length > _maxLogLength)
            {
                _logText.text = ""; 
            }
            _logText.text += message + "\n"; 
        }
    }

    public void LogPlayerAbility(string playerName, string abilityName)
    {
        Log($"{playerName} применил способность: {abilityName}");
    }

    public void LogAIAbility(string abilityName)
    {
        Log($"ИИ применил способность: {abilityName}");
    }
}