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

public abstract class Ability : MonoBehaviour {

    public int manaCost = 0;
    public int coolDown = 0;
    public int currentCooldown = 0;
    public int damage = 0;
    public keyBind keyBind = keyBind.None;
    public damageType dmgtype = damageType.None;
    public keyBindType keyBindType = keyBindType.None;
    string abilityName;
    string description;
    private float lastCdUpdate = 0.0f;


    // Use this for initialization
    void Start () {
        Player.Instance.abilities.Add(this);
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
        foreach ( var ability in Player.Instance.abilities)
        {
            if(ability.keyBind == key)
            {
                ability.keyBind = keyBind.None;
            }
        }
        this.keyBind = key;
    }

    public void UseAbility()
    {
        if(currentCooldown == 0)
        {
            currentCooldown = coolDown;
        }    
    }
}
