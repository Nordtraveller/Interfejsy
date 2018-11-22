using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastAttack : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.LB;
        keyBind = keyBind.LB;
        dmgtype = damageType.Physical;
        damage = 1;
        name = "Fast Attack";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
