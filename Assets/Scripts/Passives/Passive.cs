using UnityEngine;
using UnityEngine.Android;

public abstract class Passive : ScriptableObject
{
    //name of the passive
    public string PassiveName;

    //called when an encounter starts
    public virtual void OnEncounterStart(GameState state)
    {

    }

    //called when a coin is flipped
    public virtual void OnCoinFlip(Coin coin, GameState state)
    {

    }

    //called after a score is calculated
    public virtual void OnScoreCalcuated(GameState state)
    {

    }

}
