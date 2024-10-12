public interface IPlayerController
{
    Unit GetUnit(); 
    IPlayerInput PlayerInput { get; } 
    void UpdateView();
    void EnableInput();
    void DisableInput();
}