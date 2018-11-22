using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icebolt : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        dmgtype = damageType.Ice;
        damage = 10;
        coolDown = 5;
        manaCost = 90;
        name = "Icebolt";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
