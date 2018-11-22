using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonWolf : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        dmgtype = damageType.Physical;
        damage = 30;
        coolDown = 20;
        manaCost = 150;
        name = "Summon Wolf";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
