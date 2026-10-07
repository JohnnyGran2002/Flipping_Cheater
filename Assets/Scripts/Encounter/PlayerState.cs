using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlayerState : CombatantState
{
    //all the coins the player owns
    public List<Coin> CoinInventory = new List<Coin>();    

    //abilities the player can use
    public List<Ability> Abilities = new List<Ability>();

    //passive effects affecting the player
    public List<Passive> Passives = new List<Passive>();

    //maximum coins the player can own
    public int CoinInventroyCapacity = 8;

    //maximum coins that the player can have on the board at the same time
    public int BoardCapacity = 5;

    //player's money
    public int Money;
}
