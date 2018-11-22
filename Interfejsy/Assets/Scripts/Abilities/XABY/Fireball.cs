using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.XABY;
        keyBind = keyBind.A;
        dmgtype = damageType.Fire;
        damage = 10;
        coolDown = 5;
        manaCost = 90;
        name = "Fireball";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
