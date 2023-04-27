using System;
using UnityEngine;

/// <summary>
/// GameState - Modify it based on the states in the game
/// Can be access from any other class
/// </summary>
[Serializable]
public enum GameState
{
    Initialize = 0,
    SpawnPlayers = 1,
    SpawningEnemies = 2,
    PlayerTurn = 3,
    EnemyTurn = 4,
    BattleWon = 5,
    BattleLost = 6,
}

/// <summary>
/// THis is for a turn-based game but it can be modified for any small scale game
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Action events
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    //You can also make it a property, depends on your preference
    public GameState gameState;// { get; private set; } 

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.Initialize);
    }

    public void ChangeState(GameState newState)
    {
        if (gameState == newState)
            return;

        OnBeforeStateChanged?.Invoke(newState);

        gameState = newState;
        switch (gameState)
        {
            case GameState.Initialize:
                HandleStarting();
                break;
            case GameState.SpawnPlayers:
                HandleSpawningPlayers();
                break;
            case GameState.SpawningEnemies:
                HandleSpawningEnemies();
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameState.BattleWon:
                BattleWon();
                break;
            case GameState.BattleLost:
                BattleLost();
                break;
            default:
                break;
        }

        OnAfterStateChanged?.Invoke(newState);

        Debug.Log($"New state: {newState}");
    }

    private void HandleStarting()
    {
        // Do some start setup, could be environment, cinematics etc

        // Eventually call ChangeState again with your next state

        //Change State to Spawning Player
        ChangeState(GameState.SpawnPlayers);
    }

    private void HandleSpawningPlayers()
    {
        //Spawn Players 

        //Change State to Spawning Enemies
        ChangeState(GameState.SpawningEnemies);
    }

    private void HandleSpawningEnemies()
    {
        // Spawn enemies

        //Change State to Player Turn
        ChangeState(GameState.PlayerTurn);
    }

    private void HandlePlayerTurn()
    {
        // If you're making a turn based game, this could show the turn menu, highlight available units etc

        // Keep track of how many units need to make a move, once they've all finished, change the state. This could
        // be monitored in the unit manager or the units themselves.
    }

    private void HandleEnemyTurn()
    {

    }

    private void BattleWon()
    {
        //Update UI and other managers (Input, Sfx, Vfx etc) 
    }

    private void BattleLost()
    {
        //Update UI and other managers (Input, Sfx, Vfx etc) 
    }

}

