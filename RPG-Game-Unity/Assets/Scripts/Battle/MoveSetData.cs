using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle/Move Set")]
public class MoveSetData : ScriptableObject
{
    public List<AttackData> attacks;
}
