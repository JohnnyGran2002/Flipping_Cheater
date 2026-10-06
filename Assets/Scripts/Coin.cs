using UnityEngine;

public class Coin
{
    //coin´s data
    public CoinData Data { get; private set; }

    //the side currently showing
    public CoinSide CurrentSide { get; private set; }

    //chance of landing on heads(0 = 0% and 1 = 100%)
    public float HeadsChance { get; private set; } = 0.5f;

    public Coin(CoinData data)
    {
        Data = data;
    }

    //Flip the coin
    public void Flip()
    {
        if (Random.value < HeadsChance)
        {
            CurrentSide = Data.Heads;
        }
        else
        {
            CurrentSide = Data.Tails;
        }
    }

    //change haeds chance
    public void SetHeadsChance(float chance)
    {
        //clamps the value between 0 and 1
        HeadsChance = Mathf.Clamp01(chance);
    }
}
