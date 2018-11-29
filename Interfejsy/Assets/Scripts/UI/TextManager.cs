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
    [SerializeField] private Text currentAbilityDescription;
    [SerializeField] private Text skillDescription;
    [SerializeField] private Text itemDesciption;
    [SerializeField] private Text dmgDone;
    [SerializeField] private Text[] cdredu;

    // Use this for initialization
    void Start ()
    {
        skillPointsToSpendText.text = GetComponent<Player>().skillPointsToSpend.ToString();
        abilityDescription.text = "";
        UpdateStats();
        DoDmg();
    }
	
	// Update is called once per frame
	void Update () {
	    skillPointsToSpendText.text = GetComponent<Player>().skillPointsToSpend.ToString();
        UpdateStats();
        UpdateAbilityDescription();
	    UpdateSkillDescription();
        UpdateItemDescription();
        ManageCdRedu();
        DoDmg();

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
            for (int i = 0; i < 6; i++)
            {
                if (GetComponent<MenusManager>().abillitiesMenu.currentItem == GetComponent<MenusManager>().abillitiesMenu.itemsView[i, 3])
                {
                   abilityDescription.text = "";
                   currentAbilityDescription.text = GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>().GetCompleteDescription();
                    return;
                }
            }
            abilityDescription.text = GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>().GetCompleteDescription();
            for (int i =0; i<6; i++)
            {
                if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].changeAbility)
                {
                    currentAbilityDescription.text = GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].GetCompleteDescription();
                    return;
                }
            }
            currentAbilityDescription.text = "";
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

    public void ManageCdRedu()
    {
        for (int i = 0; i < 6; i++)
        {
            if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].currentCooldown > 0.0f)
            {
                cdredu[i].text = Mathf.Round(GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].currentCooldown +1).ToString();
            }
        }
    }

    public void DoDmg()
    {
        for (int i = 0; i < 6; i++)
        {
            if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].currentCooldown > 0.0f)
            {
                if(GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].abilityStats.dmgtype == damageType.Ice)
                {
                    dmgDone.text = "-" + GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].abilityStats.damage;
                    Debug.Log("pies");
                }
                else
                {
                    dmgDone.text = "-0";
                 }
            }
            else
            {
               // dmgDone.text = "";
            }
        }
    }
}
