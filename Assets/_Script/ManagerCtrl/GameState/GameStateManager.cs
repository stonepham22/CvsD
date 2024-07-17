using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    private GameStateManager() { }
    private GameState _currentGameState = GameState.Gameplay;

    // public delegate void GameStateChangeHandler(GameState newGameState);
    // public event GameStateChangeHandler OnGameStateChanged;

    public void SetState(GameState newGameState)
    {
        if (newGameState == _currentGameState) return;
        _currentGameState = newGameState;
        // OnGameStateChanged?.Invoke(newGameState);
    }

}