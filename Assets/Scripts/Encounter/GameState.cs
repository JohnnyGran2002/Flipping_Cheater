using UnityEngine;

public class GameState : MonoBehaviour
{
    //the player
    public PlayerState Player;

    //the NPC
    public NPCState opponent;

    //current encounter phase
    public EncounterPhase Phase;
}
