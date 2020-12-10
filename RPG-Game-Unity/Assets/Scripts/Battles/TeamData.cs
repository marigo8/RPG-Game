using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Team")]
public class TeamData : ScriptableObject
{
    public List<FighterData> fighters;
}
