using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Skill : MonoBehaviour {

    [SerializeField] public SkillStats skillStats;
    [SerializeField] private Image[] vizualizationBars;
    [SerializeField] private Skill[] skillsNeedToBeUnlocked;
    [SerializeField] private bool unlocked;

    public void AddSkill()
    {
        if (!unlocked && GameObject.Find("GameManagers").GetComponent<Player>().skillPointsToSpend > 0)
        {
            bool unlockAble = false;
            if (skillsNeedToBeUnlocked.Length == 0)
            {
                unlockAble = true;
            }
            else
            {
                foreach (var skill in skillsNeedToBeUnlocked)
                {
                    if (skill.unlocked)
                    {
                        unlockAble = true;
                    }
                }
            }

            if (unlockAble)
            {
                unlocked = true;
                GameObject.Find("GameManagers").GetComponent<Player>().skillPointsToSpend--;
                GameObject.Find("GameManagers").GetComponent<Player>().unlockedSkills.Add(this);
                if (vizualizationBars.Length > 0)
                {
                    foreach (var bar in vizualizationBars)
                    {
                        bar.GetComponent<Image>().color = Color.red;
                    }
                }
            }
        }
    }

    public string GetCompleteDescription()
    {
        string result = skillStats.name;
        result += "\n\n" + skillStats.description;
        return result;
    }
}
