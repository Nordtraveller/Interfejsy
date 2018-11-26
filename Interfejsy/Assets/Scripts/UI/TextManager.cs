using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {


    [SerializeField] private Text statPointsToSpendText;
    [SerializeField] private Text skillPointsToSpendText;
    [SerializeField] private Text strenght;
    [SerializeField] private Text agility;
    [SerializeField] private Text intelligence;
    [SerializeField] private Text charisma;
    [SerializeField] private Text abilityDescription;
    [SerializeField] private Text skillDescription;
    [SerializeField] private Text itemDesciption;

    // Use this for initialization
    void Start ()
    {
        skillPointsToSpendText.text = GetComponent<Player>().skillPointsToSpend.ToString();
        abilityDescription.text = "";
        UpdateStats();
    }
	
	// Update is called once per frame
	void Update () {
	    skillPointsToSpendText.text = GetComponent<Player>().skillPointsToSpend.ToString();
        UpdateStats();
        UpdateAbilityDescription();
	    UpdateSkillDescription();
        UpdateItemDescription();
	}

    void UpdateStats()
    {
        statPointsToSpendText.text = GetComponent<Player>().statPointsToSpend.ToString();
        strenght.text = "Strenght:\t" + GetComponent<Player>().stats[0].ToString();
        agility.text = "Agility:\t" +  GetComponent<Player>().stats[1].ToString();
        intelligence.text = "Intelligence:\t" +  GetComponent<Player>().stats[2].ToString();
        charisma.text = "Charisma:\t" +  GetComponent<Player>().stats[3].ToString();
    }

    void UpdateAbilityDescription()
    {
        if (GetComponent<MenusManager>().abillitiesMenu.enabled)
        {
            abilityDescription.text = GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>().GetCompleteDescription();
        }
    }

    void UpdateSkillDescription()
    {
        if (GetComponent<MenusManager>().skillTree.enabled)
        {
            skillDescription.text = GetComponent<MenusManager>().skillTree.currentItem.GetComponent<Skill>().GetCompleteDescription();
        }
    }

    void UpdateItemDescription()
    {
        if (GetComponent<MenusManager>().equipmentMenu.enabled)
        {
            var item = GetComponent<MenusManager>().equipmentMenu.currentItem.GetComponent<Item>();
            if (item)
            {
                itemDesciption.text = item.getCompleteDesciption();
            }
            else
            {
                itemDesciption.text = "";
            }

           
        }
    }
}
