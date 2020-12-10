using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class BattleBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("controller")] public BattleData data;

    public TeamBehaviour playerTeam, enemyTeam;

    public FighterBehaviour selectedFighter, selectedTarget;
    public SkillData selectedSkill;

    private Animator anim;

    public void SelectFighter(GameObject obj)
    {
        var fighter = obj.GetComponent<FighterBehaviour>();
        if (fighter == null) return;
        selectedFighter = fighter;
        Debug.Log("Selected Attacker: "+fighter.name);
        
        anim.SetTrigger("Skill");
    }

    public void SelectTarget(GameObject obj)
    {
        var fighter = obj.GetComponent<FighterBehaviour>();
        if (fighter == null) return;
        selectedTarget = fighter;
        Debug.Log("Selected Target: "+fighter.name);
        
        anim.SetTrigger("Confirm");
    }

    public void SelectSkill(int skillIndex)
    {
        if (selectedFighter == null) return;
        
        var skills = selectedFighter.data.skills;
        
        if (skills.Capacity <= skillIndex) return;
        
        selectedSkill = skills[skillIndex];
        Debug.Log("Selected Skill: "+ selectedSkill.name);

        if (selectedSkill.category == data.attackID)
        {
            anim.SetTrigger("TargetEnemy");
        }
        else if (selectedSkill.category == data.supportID)
        {
            anim.SetTrigger("TargetPlayer");
        }
        else
        {
            anim.SetTrigger("Confirm");
        }
    }

    public void StartPlayerTurn()
    {
        if (selectedSkill.category == data.attackID)
        {
            MoveAttacker();
        }
    }

    private void MoveAttacker()
    {
        StartCoroutine(selectedFighter.Attack(selectedTarget, selectedSkill));
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerTeam.SetUpTeam(data.playerTeam);
        enemyTeam.SetUpTeam(data.enemyTeam);
    }
}
