using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;

public class GameUI : MonoBehaviour
{
    [Header("TMP Texts")]
    [SerializeField] private TMP_Text _playerPointsText;
    [SerializeField] private TMP_Text _opponentPointsText;

    [Header("Transforms")]
    [SerializeField] private Transform _playerBoardCointainer;
    [SerializeField] private Transform _opponentBoardContainer;
    [SerializeField] private Transform _availableCoinContainer;

    [Header("Coin UI Prefab")]
    [SerializeField] private CoinView _coinPrefab;

    private GameManager _gameManager;

    //player board system
    private PlayerBoard _playerBoard;

    public void Setup(GameManager manager)
    {
        _gameManager = manager;
    }

    //set up the player board
    public void SetupPlayerBoard(PlayerBoard playerBoard)
    {
        _playerBoard = playerBoard;
    }


    //update UI fron the game state
    public void UpdateUI(GameState state)
    {

        if (state == null)
        {
            Debug.Log("GameUI received a NULL GameState!");
            return;
        }

        UpdatePoints(state);
        UpdateCoins(state);
    }

    //update the point text
    private void UpdatePoints(GameState state)
    {
        _opponentPointsText.text = "Points: " + state.Opponent.Points;

        _playerPointsText.text = "Points: " + state.Player.Points;
    }

    //update what all the coins displays
    private void UpdateCoins(GameState state)
    {
        ClearContainer(_opponentBoardContainer);
        ClearContainer(_playerBoardCointainer);
        ClearContainer(_availableCoinContainer);

        //show opponent's coins
        foreach (Coin coin in state.Opponent.BoardCoins)
        {
            CreateCoinView(coin, _opponentBoardContainer);
        }

        //make sure an encounter exists
        if (state.PlayerEncounter == null)
        {
            Debug.Log("PlayerEncounter is null.");
            return;
        }
        Debug.Log("Available coins: " + state.PlayerEncounter.AvailableCoins.Count);

        Debug.Log("Player board coins: " + state.PlayerEncounter.BoardCoins.Count);
        //show player's board coins
        foreach (Coin coin in state.PlayerEncounter.BoardCoins)
        {
            CreateCoinView(coin, _playerBoardCointainer);
        }

        //show available coins in player temporary/encounter inventory
        for (int i = 0; i < state.PlayerEncounter.AvailableCoins.Count; i++)
        {
            Debug.Log("Creating available coin UI: " + i);
            CoinView coinView = CreateCoinView(state.PlayerEncounter.AvailableCoins[i], _availableCoinContainer);

            //add the click event later
            AddClickHandler(coinView, i);
        }


    }

    private CoinView CreateCoinView(Coin coin, Transform container)
    {
        if (coin == null)
        {
            Debug.LogError("GameUI: Coin is null.");
            return null;
        }

        if (container == null)
        {
            Debug.LogError("GameUI: Coin container is missing.");
            return null;
        }

        if (_coinPrefab == null)
        {
            Debug.LogError("GameUI: Coin prefab is missing.");
            return null;
        }

        Debug.Log("Creating coin UI: " + coin.Data.CoinName);

        CoinView coinView = Instantiate(_coinPrefab, container);

        coinView.Setup(coin);

        return coinView;
    }

    //add clicking to a availabe coin in player temporary/encounter inventory
    private void AddClickHandler(CoinView coinView, int index)
    {
        coinView.SetClickAction(() => { FlipCoin(index); });
    }

    //remove all children from container
    private void ClearContainer(Transform container)
    {
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }

    //flip an available coin form player's temp/ecounter inventory
    private void FlipCoin(int index)
    {
        Debug.Log("FlipCoin called. Index: " + index);

        //check if there is a player board
        if (_playerBoard == null)
        {
            Debug.LogError("PlayerBoard is NULL.");
            return;
        }

        Debug.Log("Before flip - Available: " + _gameManager.GameState.PlayerEncounter.AvailableCoins.Count + " Board: " + _gameManager.GameState.PlayerEncounter.BoardCoins.Count);

        //try to flip the coin
        bool success = _playerBoard.FlipCoin(index);

        Debug.Log("Flip success: " + success);

        if (!success) return;

        Debug.Log("After flip - Available: " + _gameManager.GameState.PlayerEncounter.AvailableCoins.Count + " Board: " + _gameManager.GameState.PlayerEncounter.BoardCoins.Count);

        //refresh the UI
        UpdateUI(_gameManager.GameState);
    }
}
