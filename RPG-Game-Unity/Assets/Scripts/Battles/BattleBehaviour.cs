using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBehaviour : MonoBehaviour
{
    public BattleData data;

    public ID fighterID, attackPointID;

    public List<IDChildrenBehaviour> playerTeam, enemyTeam;

    private void Start()
    {
        LoadTeam(data.playerFighters, playerTeam);
        LoadTeam(data.enemyFighters, enemyTeam);
    }

    private void LoadTeam(List<CharacterData> assetFighters, List<IDChildrenBehaviour> sceneFighters)
    {
        for (var i = 0; i < assetFighters.Count; i++)
        {
            if (assetFighters[i] != null)
            {
                var fighter = sceneFighters[i].GetChildWithId(fighterID);

                fighter.GetComponent<MeshRenderer>().material.color = assetFighters[i].debugColor;
            }
            else
            {
                sceneFighters[i].gameObject.SetActive(false);
            }
        }
    }
}
