using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Coin Effects/Multiply")]
public class MultiplyEffect : CoinEffect
{
    public int multiplier;

    public override void Apply(PointContext context)
    {
        //multiply with points
        context.Points *= multiplier;
    }
}
