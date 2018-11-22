using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        keyBind = keyBind.Y;
        dmgtype = damageType.Ice;
        damage = 2;
        coolDown = 8;
        manaCost = 70;
        name = "Freeze";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
