using UnityEngine;

[CreateAssetMenu(menuName = "Coin Effects/Multiply", order = 2)]
public class MultiplyEffect : CoinEffect
{
    public int multiplier;

    public override void Apply(PointContext context)
    {
        //multiply with points
        context.Points *= multiplier;
    }
}
