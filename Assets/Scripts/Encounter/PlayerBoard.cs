using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBoard
{
    //the player's real/permanent state
    private PlayerState _player;

    //the temporary state created for current encounter
    private PlayerEncounterState _encounter;

    public PlayerBoard(PlayerState player, PlayerEncounterState encounter)
    {
        _player = player;
        _encounter = encounter;
    }

    //check if the is space for more coins on the board
    public bool CanFlipCoin()
    {
        return _encounter.BoardCoins.Count < _player.BoardCapacity;
    }

    //check if another player coin can fit on the board
    public bool CanAddCoin()
    {
        return _encounter.BoardCoins.Count < _player.BoardCapacity;
    }

    //flip an available coin and place it at the end/most to the right of the board
    public bool FlipCoin(int inventoryIndex)
    {
        //make sure the index is valid
        if (inventoryIndex < 0 || inventoryIndex >= _encounter.AvailableCoins.Count) { return false; }

        //check if there is space left
        if (!CanFlipCoin())
        {
            return false;
        }

        //get the selected coin
        Coin coin = _encounter.AvailableCoins[inventoryIndex];

        //remove it from available coins
        _encounter.AvailableCoins.RemoveAt(inventoryIndex);

        //flip the coin
        coin.Flip();

        //add it to the end/most to the right of the board
        _encounter.BoardCoins.Add(coin);

        return true;
    }

    public bool ReturnCoin(int boardIndex)
    {
        //make sure the index is valid
        if (boardIndex < 0 || boardIndex >= _encounter.AvailableCoins.Count) return false;

        //get the coin
        Coin coin = _encounter.BoardCoins[boardIndex];

        //remove the coin from the board
        _encounter.BoardCoins.RemoveAt(boardIndex);

        //return it to the available coins
        _encounter.AvailableCoins.Add(coin);

        return true;
    }

    //remove a coin from the board and the ecounter entirely
    public bool RemoveCoin(int boardIndex)
    {
        //make sure the index is valid
        if (boardIndex < 0 || boardIndex >= _encounter.AvailableCoins.Count) return false;

        //remove the coin from the board
        _encounter.BoardCoins.RemoveAt(boardIndex);

        return true;
    }

    //sawp the position of two coins
    public bool SwapTwoCoinsPosition(int indexA, int indexB)
    {
        //make sure both positions exist
        if (indexA < 0 || indexA >= _encounter.BoardCoins.Count) { return false; }

        if (indexB < 0 || indexB >= _encounter.BoardCoins.Count) { return false; }

        //store the first coin to be placed later
        Coin temp = _encounter.BoardCoins[indexA];

        //move the first coin to the second coin´s position
        _encounter.BoardCoins[indexA] = _encounter.BoardCoins[indexB];

        //move the second coin to the first coins postions
        _encounter.BoardCoins[indexB] = temp;

        return true;
    }

    //reflip a coin on the board
    public bool ReflipCoin(int boardIndex)
    {
        //make sure the index is valid
        if (boardIndex < 0 || boardIndex >= _encounter.AvailableCoins.Count) return false;

        //reflip the selected coin
        _encounter.BoardCoins[boardIndex].Flip();

        return true;
    }
}
