using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Abilities/Reflip")]
public class ReflipAbility : Ability
{
    public override void Execute(GameState state)
    {
        if (state.Phase != EncounterPhase.PlayerPhase) return;

        if (state.PlayerEncounter.BoardCoins.Count == 0) return;

        //reflip the first coinf for now, change to being able to select later
        state.PlayerEncounter.BoardCoins[0].Flip();
    }
}
