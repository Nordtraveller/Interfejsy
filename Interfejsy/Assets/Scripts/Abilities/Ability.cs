﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum damageType
{
    None,
    Fire,
    Ice,
    Heal,
    Physical
}


[System.Serializable]
public enum keyBindType
{
    None,
    LB,
    RB,
    XABY
}

public class Ability : MonoBehaviour {

    [SerializeField] public AbilityStats abilityStats;
    private int currentCooldown = 0;
    private float lastCdUpdate = 0.0f;
    public bool changeAbility;


    // Use this for initialization
    void Start () {
        changeAbility = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(currentCooldown > 0)
        {
            lastCdUpdate += Time.deltaTime;
            if (lastCdUpdate >= 1.0f)
            {
                lastCdUpdate = 0f;
                currentCooldown -= 1;
            }
        }
	}

    public void UseAbility()
    {
        if(currentCooldown == 0)
        {
            currentCooldown = abilityStats.coolDown;
        }    
    }

    public string GetCompleteDescription()
    {
        string result = abilityStats.name;
        if (abilityStats.manaCost > 0)
        {
            result += "\tmana:" + abilityStats.manaCost;
        }
        else
        {
            result += "\t";
        }
        if (abilityStats.damage > 0)
        {
            result += "\tdamage:" + abilityStats.damage + "(" + abilityStats.dmgtype + ")";
        }
        else
        {
            result += "\t";
        }
        if (abilityStats.coolDown > 0)
        {
            result += "\tcd:" + abilityStats.coolDown;
        }
        result += "\n\n" + abilityStats.description;
        return result;
    }

    public void ActivateChangeAbility()
    {
        if (this.changeAbility)
        {
            this.changeAbility = false;
            return;
        }

        for (int i = 0; i < 6; i++)
        {
            if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].changeAbility)
            {
                GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].changeAbility = false;
                break;
            }
        }
        this.changeAbility = true;

    }

    public void ChangeAbility()
    {
        Ability oldAbility = null;
        Ability alreadyUsed = null;
        for (int i=0; i<6; i++)
        {
            if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].abilityStats.name == this.abilityStats.name)
            {
                alreadyUsed = GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i];
            }
            if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].changeAbility)
            {
                oldAbility = GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i];
            }
        }
        if(oldAbility == null)
        {
            return;
        }
        if(oldAbility.abilityStats.keyBindType != this.abilityStats.keyBindType)
        {
            return;
        }
        if (alreadyUsed != null)
        {
            alreadyUsed.abilityStats = oldAbility.abilityStats;
        }
        oldAbility.abilityStats = this.abilityStats;
        oldAbility.changeAbility = false;
    }
}
