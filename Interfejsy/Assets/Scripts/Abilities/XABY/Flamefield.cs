using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamefield : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        keyBind = keyBind.B;
        dmgtype = damageType.Fire;
        damage = 20;
        coolDown = 12;
        manaCost = 130;
        name = "Flamefield";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
