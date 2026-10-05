using UnityEngine;

public abstract class CoinEffect : ScriptableObject
{
    //apply this effect to the current points
    public abstract void Apply(PointContext context);
}
