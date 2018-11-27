using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Ability/Stats", order = 1)]
public class AbilityStats : ScriptableObject {
    public Sprite icon;
    public int manaCost = 0;
    public float coolDown = 0;
    public int damage = 0;
    public damageType dmgtype = damageType.None;
    public keyBindType keyBindType = keyBindType.None;
    public string abilityName;
    public string description;
}
