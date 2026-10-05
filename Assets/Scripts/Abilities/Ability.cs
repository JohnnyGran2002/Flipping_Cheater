using UnityEngine;
using UnityEngine.Android;

public abstract class Ability : ScriptableObject
{
    //name of the ability
    public string AbilityName;

    //use the ability
    public abstract void Execute(GameState state);
}
