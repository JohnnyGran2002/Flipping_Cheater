using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Coin")]
public class CoinData : ScriptableObject
{
    //the name of the coin
    public string CoinName;

    //sprite for when in lands on heads or tails
    public Sprite HeadsSprite;
    public Sprite TailsSprite;

    //the effect that happens when the coin lands on heads or tail
    public CoinSide Heads;
    public CoinSide Tails;
}

[System.Serializable]
public class CoinSide
{
    //basic value of this side of the coin
    public int Value;

    //extra effects
    public List<CoinEffect> Effects;
}