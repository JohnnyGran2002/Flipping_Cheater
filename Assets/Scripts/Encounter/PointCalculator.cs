using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PointCalculator
{
    //calculate a score from a board of coins
    public int Calculate(List<Coin> board, CombatantState owner, CombatantState opponent)
    {
        //start at 0
        int points = 0;

        //go through all the coins from left to right
        for (int i = 0; i < board.Count; i++)
        {
            Coin coin = board[i];

            //ignore coins that have not been flipped
            if (coin.CurrentSide == null)
            {
                continue;
            }

            //add the coin´s base value
            points += coin.CurrentSide.Value;

            //apply the coins effects
            if (coin.CurrentSide.Effects != null)
            {
                foreach (CoinEffect effect in coin.CurrentSide.Effects)
                {
                    PointContext context = new PointContext();

                    //set up the context
                    context.Points = points;
                    context.CoinIndex = i;
                    context.CurrentCoin = coin;
                    context.Owner = owner;
                    context.Opponent = opponent;

                    //apply the effect
                    effect.Apply(context);

                    //get the modified points back
                    points = context.Points;
                }
            }
        }

        //return the final points
        return points;
    }
}
