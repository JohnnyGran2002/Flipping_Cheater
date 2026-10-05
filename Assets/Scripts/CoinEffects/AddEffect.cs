using UnityEngine;

[CreateAssetMenu(menuName = "Coin Effects/Add", order = 1)]
public class AddEffect : CoinEffect
{
    public int amount;

    public override void Apply(PointContext context)
    {
        //add amount to points
        context.Points += amount;
    }
}
