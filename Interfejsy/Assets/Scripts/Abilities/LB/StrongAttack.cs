using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.LB;
        dmgtype = damageType.Physical;
        damage = 3;
        name = "Strong Attack";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
