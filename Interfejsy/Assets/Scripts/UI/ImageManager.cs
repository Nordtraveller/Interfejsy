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
    [SerializeField] private Image [] abilityVisualizationBars;
    [SerializeField] private Image lbAbility;
    [SerializeField] private Image xAbility;
    [SerializeField] private Image aAbility;
    [SerializeField] private Image bAbility;
    [SerializeField] private Image yAbility;
    [SerializeField] private Image rbAbility;
    [SerializeField] private Image[] abilityChanging;
    [SerializeField] private Image changeAbilityButton;
    [SerializeField] private Image addingSkillButton;
    [SerializeField] private Image changeItemButton;
    [SerializeField] private Image[] havePointsToSpendBars;
    [SerializeField] private Image[] cdreduImages;
    [SerializeField] private Image abilityDescription;
    [SerializeField] private Image currentAbilityDescription;
    [SerializeField] private Image[] currentXboxButton;
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
        UpdateAbilityDescription();
        ManageChangeAbilityButton();
        setColourOfhavePointsToSpendBars();
        ManageAddSKillButton();
        ManageChangeItemButton();
        updateCurrentItems();
        ManageCdRedu();
        ManageGreenFadeInSkillTree();
    }

    void setColourOfhavePointsToSpendBars()
    {
        if (GetComponent<Player>().skillPointsToSpend > 0)
        {
            foreach (var bar in havePointsToSpendBars)
            {
                bar.GetComponent<Image>().color = Color.yellow;
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
        if (GetComponent<Player>().statPointsToSpend == 0) {
            color = Color.gray;
            for (int i = 0; i < abilityVisualizationBars.Length; i++)
            {
                abilityVisualizationBars[i].GetComponent<Image>().color = Color.gray;
            }
        }
        else
        {
            for (int i = 0; i < abilityVisualizationBars.Length; i++)
            {
                abilityVisualizationBars[i].GetComponent<Image>().color = Color.yellow;
            }
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

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null)
                    {
                        currentXboxButton[(col * 5) + row + col].gameObject.SetActive(false);
                    }
                }
            }
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
                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null)
                        {
                            if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col].GetComponent<Ability>().abilityStats.name == GetComponent<Player>().currentAbilities[i].abilityStats.name)
                            {
                                Image[] temp = GetComponent<MenusManager>().abillitiesMenu.itemsView[i, 3].GetComponentsInChildren<Image>();
                                for (int a = 0; a < temp.Length; a++)
                                {
                                    if (temp[a].name == "xboxButton")
                                    {
                                        currentXboxButton[(col * 5) + row + col].sprite = temp[a].sprite;
                                    }
                                }
                                currentXboxButton[(col * 5) + row + col].gameObject.SetActive(true);
                            }
                        }

                    }
                }
            }

            //makegridInactiveOrActive
            for (int i = 0; i < 6; i++)
            {
                if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].changeAbility)
                {
                    if (i == 0 || i == 5)
                    {
                        for (int row = 0; row < 6; row++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null && row != i)
                                {
                                    GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col].active = false;
                                }
                                else
                                {
                                    if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null)
                                    {
                                        GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col].active = true;
                                    }
                                }
                                if (row == 5 && col == 2)
                                {
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int row = 0; row < 6; row ++)
                        {
                            for (int col = 0; col < 3; col++)
                            {
                                if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null && (row == 0 || row == 5))
                                {
                                    GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col].active = false;
                                }
                                else
                                {
                                    if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null)
                                    {
                                        GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col].active = true;
                                    }
                                }
                                if (row == 5 && col == 2)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col] != null)
                    {
                        GetComponent<MenusManager>().abillitiesMenu.itemsView[row, col].active = true;
                    }
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

    void ManageChangeItemButton()
    {
        if (GetComponent<MenusManager>().equipmentMenu.enabled)
        {
            var isItem = GetComponent<MenusManager>().equipmentMenu.currentItem.GetComponent<Item>();
            if (isItem == null)
            {
                changeItemButton.gameObject.SetActive(false);
            }
            else
            {
                // User moves along Items

                // Check if user has in focus "current" item (lower panel)
                var itemsGrid = GetComponent<MenusManager>().equipmentMenu.itemsView;
                List<GridItem> gridItems = new List<GridItem>();
           
                // Only active items
                for (int i = 0; i < 4; i++)
                {
                    if (GetComponent<MenusManager>().equipmentMenu.currentItem == itemsGrid[i,2])
                    {
                        changeItemButton.gameObject.SetActive(true);
                        return;
                    }
                }

                changeItemButton.gameObject.SetActive(false);
            }
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

    void UpdateAbilityDescription()
    {
        if (GetComponent<MenusManager>().abillitiesMenu.enabled)
        {
            for (int i = 0; i < 6; i++)
            {
                if (GetComponent<MenusManager>().abillitiesMenu.currentItem == GetComponent<MenusManager>().abillitiesMenu.itemsView[i, 3])
                {
                    abilityDescription.gameObject.SetActive(false);
                    currentAbilityDescription.gameObject.SetActive(true);
                    return;
                }
            }
            abilityDescription.gameObject.SetActive(true);
            for (int i = 0; i < 6; i++)
            {
                if (GameObject.Find("GameManagers").GetComponent<Player>().currentAbilities[i].changeAbility)
                {
                    currentAbilityDescription.gameObject.SetActive(true);
                    return;
                }
            }
            currentAbilityDescription.gameObject.SetActive(false);
        }
    }

    void ManageGreenFadeInSkillTree()
    {
        foreach (var skill in GetComponent<Player>().skills)
        {
            if (skill.CheckIfUnlockAble())
            {
                skill.fadeSkillImage.GetComponent<Image>().color = Color.green;
            }
            else
            {
                skill.fadeSkillImage.GetComponent<Image>().color = Color.white;
            }
        }
    }

}
