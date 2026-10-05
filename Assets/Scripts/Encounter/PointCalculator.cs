using System.Collections.Generic;
using UnityEngine;

public class PointCalculator : MonoBehaviour
{
    //calculate a combatant´s score
    public int Calculate(CombatantState owner, CombatantState opponent)
    {
        //create the points text
        PointContext context = new PointContext();

        context.Owner = owner;
        context.Opponent = opponent;

        //start at 0
        context.Points = 0;

        //procces the coins from left to right
        for(int i = 0; i < context.Points; i++)
        {
            Coin coin = owner.Coins[i];

            //store current coin data
            context.CoinIndex = i;
            context.CurrentCoin = coin;

            //add the coin's base value
            context.Points += coin.CurrentSide.Value;

            //apply the side's effect
            if(coin.CurrentSide.Effects != null)
            {
                foreach (CoinEffect effect in coin.CurrentSide.Effects)
                {
                    effect.Apply(context);
                }
            }
        }

        //return the final score
        return context.Points;
    }
}
