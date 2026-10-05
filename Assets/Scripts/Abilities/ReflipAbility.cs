using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Reflip", order = 1)]
public class ReflipAbility : Ability
{
    public override void Execute(GameState state)
    {
        if (state.Phase != EncounterPhase.PlayerPhase) return;

        if (state.Player.Coins.Count == 0) return;

        //reflip the first coinf for now, change to being able to select later
        state.Player.Coins[0].Flip();
    }
}
