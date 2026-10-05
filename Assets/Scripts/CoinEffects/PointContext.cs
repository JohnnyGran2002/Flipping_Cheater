using UnityEngine;

public class PointContext : MonoBehaviour
{
    //current points
    public int Points;

    //position of the current coin
    public int CoinIndex;

    //coin currently being processed
    public Coin CurrentCoin;

    //who owns the coin currently being calculated
    public CombatantState Owner;

    //the opposing side
    public CombatantState Opponent;
}
