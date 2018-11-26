using System.Collections;
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
public enum keyBind
{
    None,
    LB,
    RB,
    X,
    A,
    B,
    Y
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


    // Use this for initialization
    void Start () {

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

    void BindAbility(keyBind key)
    {
    //todo
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
}
