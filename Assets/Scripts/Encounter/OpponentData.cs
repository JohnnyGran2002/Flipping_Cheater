using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptable Objects/Opponent")]
public class OpponentData : ScriptableObject
{
    public List<CoinData> Coins;
}
