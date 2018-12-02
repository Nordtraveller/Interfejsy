using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Skill : MonoBehaviour {

    [SerializeField] public SkillStats skillStats;
    [SerializeField] private Image[] vizualizationBars;
    [SerializeField] public Image fadeSkillImage;
    [SerializeField] private Skill[] skillsNeedToBeUnlocked;
    [SerializeField] private bool unlocked;

    public void AddSkill()
    {
        if (CheckIfUnlockAble())
        {
            unlocked = true;
            GameObject.Find("GameManagers").GetComponent<Player>().skillPointsToSpend--;
            GameObject.Find("GameManagers").GetComponent<Player>().unlockedSkills.Add(this);
            fadeSkillImage.gameObject.SetActive(false);
            if (vizualizationBars.Length > 0)
            {
                foreach (var bar in vizualizationBars)
                {
                    bar.GetComponent<Image>().color = Color.yellow;
                }
            }
        }
    }

    public bool CheckIfUnlockAble()
    {
        bool unlockAble = false;
        if (!unlocked && GameObject.Find("GameManagers").GetComponent<Player>().skillPointsToSpend > 0)
        {
            
            if (skillsNeedToBeUnlocked.Length == 0)
            {
                unlockAble = true;
                return unlockAble;
            }
            else
            {
                foreach (var skill in skillsNeedToBeUnlocked)
                {
                    if (skill.unlocked)
                    {
                        unlockAble = true;
                        return unlockAble;
                    }
                }
            }
        }

        return unlockAble;
    }

    public string GetCompleteDescription()
    {
        string result = skillStats.description;
        return result;
    }
}
