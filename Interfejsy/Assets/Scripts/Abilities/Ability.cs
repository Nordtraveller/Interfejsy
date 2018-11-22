using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum damageType
{
    None,
    Fire,
    Ice,
    Heal,
    Physical
}

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
    public int damage = 0;
    public keyBind keyBind = keyBind.None;
    public damageType dmgtype = damageType.None;
    public keyBindType keyBindType = keyBindType.None;
    string abilityName;
    string description;


    // Use this for initialization
    void Start () {
        Player.Instance.abilities.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
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

}
