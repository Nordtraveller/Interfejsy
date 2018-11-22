using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        keyBind = keyBind.X;
        dmgtype = damageType.Fire;
        coolDown = 3;
        manaCost = 50;
        name = "Dash";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
