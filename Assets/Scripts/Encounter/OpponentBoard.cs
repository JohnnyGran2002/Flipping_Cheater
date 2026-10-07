using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class OpponentBoard
{
    //the enemy's state
    private NPCState _opponent;

    public OpponentBoard(NPCState opponent)
    {
        _opponent = opponent;
    }

    //add a coin to the opponent's board
    public void AddCoin(Coin coin)
    {
        _opponent.BoardCoins.Add(coin);
    }

    //set the starting side of this coin
    public void SetCoinSide(Coin coin, bool heads)
    {
        //make sure the coin is on the board
        if (!_opponent.BoardCoins.Contains(coin)) { return; }

        //set the desired side
        coin.SetSide(heads);
    }

    //reflip one of the opponent's coins
    public bool ReflipCoin(Coin coin)
    {
        //make sure the coin is on the board
        if (!_opponent.BoardCoins.Contains(coin)) { return false; }

        //flip the coin
        coin.Flip();

        return true;
    }

    //swap the position of two of the opponent's coins
    public bool SwapTwoCoinsPositions(int indexA, int indexB)
    {
        //make sure both positions exist
        if (indexA < 0 || indexA >= _opponent.BoardCoins.Count) { return false; }

        if (indexB < 0 || indexB >= _opponent.BoardCoins.Count) { return false; }

        //store the first coin to be placed later
        Coin temp = _opponent.BoardCoins[indexA];

        //move the first coin to the second coin´s position
        _opponent.BoardCoins[indexA] = _opponent.BoardCoins[indexB];

        //move the second coin to the first coins postions
        _opponent.BoardCoins[indexB] = temp;

        return true;
    }

    //remove an enemy coin
    public bool RemoveCoin(Coin coin)
    {
        return _opponent.BoardCoins.Remove(coin);
    }

}
