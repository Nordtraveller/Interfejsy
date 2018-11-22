using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAttack : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.LB;
        dmgtype = damageType.Physical;
        damage = 2;
        name = "Thrust Attack";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
