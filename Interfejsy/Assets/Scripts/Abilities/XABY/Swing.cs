using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        dmgtype = damageType.Physical;
        damage = 5;
        coolDown = 2;
        manaCost = 20;
        name = "Swing";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
