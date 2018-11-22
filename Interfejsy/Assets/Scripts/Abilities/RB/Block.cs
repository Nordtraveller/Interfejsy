using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Ability
{
    // Use this for initialization
    void Start()
    {
        keyBindType = keyBindType.RB;
        keyBind = keyBind.RB;
        name = "Block";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
