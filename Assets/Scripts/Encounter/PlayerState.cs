using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerState : CombatantState
{
    //abilities the player can use
    public List<Ability> Abilities = new List<Ability>();

    //passive effects affecting the player
    public List<Passive> Passives = new List<Passive>();
}
