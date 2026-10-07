using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    //current game state
    public GameState GameState { get; private set; }

    //calcutates points
    private PointCalculator _pointCalculator;

    public PlayerBoard playerBoard {  get; private set; }
    public OpponentBoard opponentBoard { get; private set; }

    //Temp Test
    [SerializeField] private CoinData playerCoin1Data;
    [SerializeField] private CoinData playerCoin2Data;
    [SerializeField] private CoinData opponentCoin1Data;
    [SerializeField] private CoinData opponentCoin2Data;

    private void Awake()
    {
        //creat the game state
        GameState = new GameState();

        //create the player
        GameState.Player = new PlayerState();

        //create the NPC
        GameState.Opponent = new NPCState();

        //create the point calculator
        _pointCalculator = new PointCalculator();

        //create the board system
        playerBoard = new PlayerBoard(GameState.Player, GameState.PlayerEncounter);
        opponentBoard = new OpponentBoard(GameState.Opponent);

        //Temp Test
        SetupTestCoins();
    }

    private void Start()
    {
        StartEncounter();
    }

    //Temp Test
    private void SetupTestCoins()
    {
        //create player's coins
        Coin playerCoin1 = new Coin(playerCoin1Data);
        Coin playerCoin2 = new Coin(playerCoin2Data);

        //Add player coins to inventory
        GameState.Player.CoinInventory.Add(playerCoin1);
        GameState.Player.CoinInventory.Add(playerCoin2);

        //create opponent's coins
        Coin opponentCoin1 = new Coin(opponentCoin1Data);
        Coin opponentCoin2 = new Coin(opponentCoin2Data);

        //add opponent's coins to the board
        GameState.Opponent.BoardCoins.Add(opponentCoin1);
        GameState.Opponent.BoardCoins.Add(opponentCoin2);

    }

    //start an encounter
    private void StartEncounter()
    {
        GameState.Phase = EncounterPhase.starting;

        //trigger all start of encounter passive effects
        TriggerEncounterStart();

        //start NPC phase
        StartNPCPhase();
    }

    private void StartPlayerEncounter()
    {
        //creates a temporary state for the encounter
        GameState.PlayerEncounter = new PlayerEncounterState();

        //copy the player's real/permanent inventory into the temporary encounter inventory
        foreach (Coin coin in GameState.Player.CoinInventory)
        {
            GameState.PlayerEncounter.AvailableCoins.Add(coin);
        }
    }

    //the opponent flips all their coins
    private void StartNPCPhase()
    {
        GameState.Phase = EncounterPhase.NPCPhase;

        //flip every opponent coin
        foreach (Coin coin in GameState.Opponent.BoardCoins)
        {
            coin.Flip();

            Debug.Log("NPC coin flipped. Value: " + coin.CurrentSide.Value);
        }

        //calculate opponent´s points
        GameState.Opponent.Points = _pointCalculator.Calculate(GameState.Opponent.BoardCoins, GameState.Opponent, GameState.Player);

        //Temp Test
        Debug.Log("Opponent Points: " + GameState.Opponent.Points);

        //move on to player phase
        StartPlayerPhase();
    }

    //start the player´s phase
    private void StartPlayerPhase()
    {
        //the player can now flip coins and use abilities
        GameState.Phase = EncounterPhase.PlayerPhase;
    }

    //when player is finished
    public void FinishPlayerPhase()
    {
        //calculate player´s finalscore
        GameState.Player.Points = _pointCalculator.Calculate(GameState.PlayerEncounter.BoardCoins, GameState.Player, GameState.Opponent);

        Debug.Log("Player Points: " + GameState.Player.Points);

        //finish the encounter
        FinishEncounter();
    }

    private void FinishEncounter()
    {
        GameState.Phase = EncounterPhase.Finished;

        if (GameState.Player.Points > GameState.Opponent.Points)
        {
            Debug.Log("Player Won!");
        }
        else
        {
            Debug.Log("Player Lost!");
        }
    }

    //trigger encounter start passives
    private void TriggerEncounterStart()
    {
        foreach (Passive passive in GameState.Player.Passives)
        {
            passive.OnEncounterStart(GameState);
        }

        foreach (Passive passive in GameState.Opponent.Passives)
        {
            passive.OnEncounterStart(GameState);
        }
    }
}
