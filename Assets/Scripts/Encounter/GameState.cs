using UnityEngine;

public class GameState : MonoBehaviour
{
    //the player
    public PlayerState Player;

    //the NPC
    public NPCState Opponent;

    //the temporary player state used for the current encounter
    public PlayerEncounterState PlayerEncounter;

    //current encounter phase
    public EncounterPhase Phase;
}
