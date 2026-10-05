using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PointModifierData", menuName = "Scriptable Objects/CoinData" , order = 1)]
public class CoinData : ScriptableObject
{
    public bool head;
    public int chanceForHead = 2;
    public List<ScriptableObject> headEffects, tailEffects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomNumber = Random.Range(0, 3);
            if (randomNumber >= chanceForHead)
            {
                head = true;
                Debug.Log("Coin Landed Heads");
            }
            else
            {
                head = false;
                Debug.Log("Coin Landed Tails");
            }
        }
    }
}