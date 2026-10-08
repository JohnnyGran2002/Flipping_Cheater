using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Coin Effects/Add")]
public class AddEffect : CoinEffect
{
    public int amount;

    public override void Apply(PointContext context)
    {
        //add amount to points
        context.Points += amount;
    }

    public override string GetDescription()
    {
        return "+" + amount;
    }
}
