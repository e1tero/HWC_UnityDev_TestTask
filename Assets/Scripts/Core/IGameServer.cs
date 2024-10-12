public interface IGameServer
{
    void ApplyAbility(IPlayerController source, IPlayerController target, IAbility ability);
    void RestartGame();
    void InitializeControllers(IPlayerController playerController, IPlayerController opponentController);
}