using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{

    [SerializeField] private Image addToStrenght;
    [SerializeField] private Image addToAgility;
    [SerializeField] private Image addToIntelligence;
    [SerializeField] private Image addToCharisma;
    [SerializeField] private Image lbAbility;
    [SerializeField] private Image xAbility;
    [SerializeField] private Image aAbility;
    [SerializeField] private Image bAbility;
    [SerializeField] private Image yAbility;
    [SerializeField] private Image rbAbility;
    [SerializeField] private Image[] abilityChanging;
    [SerializeField] private Image changeAbilityButton;
    [SerializeField] private Image addingSkillButton;
    [SerializeField] private Image[] havePointsToSpendBars;
    [SerializeField] private Image[] cdreduImages;

    [SerializeField] private Image currentHead;
    [SerializeField] private Image currentSword;
    [SerializeField] private Image currentArmor;
    [SerializeField] private Image currentShield;

    [SerializeField] private Image[] itemsChanging;
    //[SerializeField] private Image change

    // Use this for initialization
    void Start()
    {
        setStatsActivity();
    }

    // Update is called once per frame
    void Update()
    {
        updateCurrentAbilities();
        ManageChangeAbilityButton();
        setColourOfhavePointsToSpendBars();
        ManageAddSKillButton();
        updateCurrentItems();
        ManageCdRedu();
    }

    void setColourOfhavePointsToSpendBars()
    {
        if (GetComponent<Player>().skillPointsToSpend > 0)
        {
            foreach (var bar in havePointsToSpendBars)
            {
                bar.GetComponent<Image>().color = Color.red;
            }
        }
        else
        {
            foreach (var bar in havePointsToSpendBars)
            {
                bar.GetComponent<Image>().color = Color.grey;
            }
        }
    }

    public void setStatsActivity()
    {
        Color color = Color.white;
        if (GetComponent<Player>().statPointsToSpend == 0)
        {
            color = Color.gray;
        }

        addToStrenght.GetComponent<Image>().color = color;
        addToAgility.GetComponent<Image>().color = color;
        addToIntelligence.GetComponent<Image>().color = color;
        addToCharisma.GetComponent<Image>().color = color;
    }

    public void updateCurrentItems()
    {
        if (GetComponent<MenusManager>().equipmentMenu.enabled)
        {
            currentHead.sprite = GetComponent<Player>().currentItems[0].itemStats.icon;
            currentSword.sprite = GetComponent<Player>().currentItems[1].itemStats.icon;
            currentArmor.sprite = GetComponent<Player>().currentItems[2].itemStats.icon;
            currentShield.sprite = GetComponent<Player>().currentItems[3].itemStats.icon;

            for (int i = 0; i < 4; ++i)
            {
                if (GetComponent<Player>().currentItems[i].changeItem)
                    itemsChanging[i].gameObject.SetActive(true);
                else
                    itemsChanging[i].gameObject.SetActive(false);
            }
        }
    }

    public void updateCurrentAbilities()
    {
        if (GetComponent<MenusManager>().abillitiesMenu.enabled)
        {
            lbAbility.sprite = GetComponent<Player>().currentAbilities[0].abilityStats.icon;
            xAbility.sprite = GetComponent<Player>().currentAbilities[1].abilityStats.icon;
            aAbility.sprite = GetComponent<Player>().currentAbilities[2].abilityStats.icon;
            bAbility.sprite = GetComponent<Player>().currentAbilities[3].abilityStats.icon;
            yAbility.sprite = GetComponent<Player>().currentAbilities[4].abilityStats.icon;
            rbAbility.sprite = GetComponent<Player>().currentAbilities[5].abilityStats.icon;
            for (int i = 0; i < 6; i++)
            {
                if (GetComponent<Player>().currentAbilities[i].changeAbility)
                {
                    abilityChanging[i].gameObject.SetActive(true);
                }
                else
                {
                    abilityChanging[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                abilityChanging[i].gameObject.SetActive(false);
                GetComponent<Player>().currentAbilities[i].changeAbility = false;
            }
        }
    }

    void ManageChangeAbilityButton()
    {
        if (GetComponent<MenusManager>().abillitiesMenu.enabled)
        {
            for (int i = 0; i < 6; i++)
            {
                if (GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>() ==
                    GetComponent<Player>().currentAbilities[i])
                {
                    changeAbilityButton.gameObject.SetActive(true);
                    return;
                }

                if (GetComponent<Player>().currentAbilities[i].changeAbility &&
                    (GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>().abilityStats
                         .keyBindType
                     == GetComponent<Player>().currentAbilities[i].abilityStats.keyBindType))
                {
                    changeAbilityButton.gameObject.SetActive(true);
                    return;
                }
            }

            changeAbilityButton.gameObject.SetActive(false);

        }
    }


    void ManageAddSKillButton()
    {
        if (GetComponent<MenusManager>().skillTree.enabled)
        {
            if (GetComponent<MenusManager>().skillTree.currentItem.GetComponent<Skill>().CheckIfUnlockAble())
            {
                addingSkillButton.gameObject.SetActive(true);
                return;
            }
        }
        addingSkillButton.gameObject.SetActive(false);
    }

    public void ManageCdRedu()
    {
        for(int i=0; i<6; i++)
        {
            if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].currentCooldown > 0.0f)
            {
                cdreduImages[i].gameObject.SetActive(true);
            }else
            {
                cdreduImages[i].gameObject.SetActive(false);
            }
        }
    }
}
