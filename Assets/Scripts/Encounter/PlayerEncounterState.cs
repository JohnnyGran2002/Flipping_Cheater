using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerEncounterState
{
    //coins currently available to use during the encounter
    public List<Coin> AvailableCoins = new List<Coin>();

    //coins currently on the board
    public List<Coin> BoardCoins = new List<Coin>();
}
