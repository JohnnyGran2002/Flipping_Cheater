using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    //current game state
    public GameState GameState { get; private set; }

    //calcutates points
    private PointCalculator _pointCalculator;

    //Temp Test
    [SerializeField] private CoinData playerCoin1;
    [SerializeField] private CoinData playerCoin2;
    [SerializeField] private CoinData opponentCoin1;
    [SerializeField] private CoinData opponentCoin2;

    private void Awake()
    {
        //creat the game state
        GameState = new GameState();

        //create the player
        GameState.Player = new PlayerState();

        //create the NPC
        GameState.opponent = new NPCState();

        //create the point calculator
        _pointCalculator = new PointCalculator();

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
        GameState.Player.Coins.Add(new Coin(playerCoin1));
        GameState.Player.Coins.Add(new Coin(playerCoin2));

        GameState.opponent.Coins.Add(new Coin(opponentCoin1));
        GameState.opponent.Coins.Add(new Coin(opponentCoin2));
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

    //the opponent flips all their coins
    private void StartNPCPhase()
    {
        GameState.Phase = EncounterPhase.NPCPhase;

        //flip every opponent coin
        foreach (Coin coin in GameState.opponent.Coins)
        {
            coin.Flip();

            Debug.Log("NPC coin flipped. Value: " + coin.CurrentSide.Value);
        }

        //calculate opponent´s points
        GameState.opponent.Points = _pointCalculator.Calculate(GameState.opponent, GameState.Player);

        //Temp Test
        Debug.Log("Opponent Points: " + GameState.opponent.Points);

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
        GameState.Player.Points = _pointCalculator.Calculate(GameState.Player, GameState.opponent);

        Debug.Log("Player Points: " + GameState.Player.Points);

        //finish the encounter
        FinishEncounter();
    }

    private void FinishEncounter()
    {
        GameState.Phase = EncounterPhase.Finished;

        if (GameState.Player.Points > GameState.opponent.Points)
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

        foreach (Passive passive in GameState.opponent.Passives)
        {
            passive.OnEncounterStart(GameState);
        }
    }

    //Temp Test
    [ContextMenu("Start Encounter")]
    private void TestStartEncounter()
    {
        StartEncounter();
    }
}
