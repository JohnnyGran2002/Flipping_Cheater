using NUnit.Framework;
using UnityEngine;

public class NPCState : CombatantState
{
    //passive or special rules affecting the NPC
    public List<Passive> Passives = new List<Passive>();
}
