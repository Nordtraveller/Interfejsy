using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        dmgtype = damageType.Heal;
        damage = 30;
        coolDown = 16;
        manaCost = 60;
        name = "Heal";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
