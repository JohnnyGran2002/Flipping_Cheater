using UnityEngine;

[CreateAssetMenu(fileName = "PointModifierData", menuName = "Scriptable Objects/PointModifierData", order = 2)]
public class PointModifierData : ScriptableObject
{
    public int points;
    public PlayerPointsTracker pointTracker;

    public void ModifyPoints()
    {
        pointTracker.PlayerPoints += points;
    }
}
