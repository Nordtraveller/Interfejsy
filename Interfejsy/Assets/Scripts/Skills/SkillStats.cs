using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skill/Stats", order = 1)]
public class SkillStats : ScriptableObject
{
    public Sprite icon;
    public string skillName;
    public string description;
}
