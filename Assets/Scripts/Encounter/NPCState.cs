using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class NPCState : CombatantState
{
    //coins currently on the enemy board
    public List<Coin> BoardCoins = new List<Coin>();

    //passive or special rules affecting the NPC
    public List<Passive> Passives = new List<Passive>();
}
