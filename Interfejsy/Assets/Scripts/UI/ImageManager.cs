using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour {

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

    // Use this for initialization
    void Start () {
        setStatsActivity();
    }
	
	// Update is called once per frame
	void Update () {
        updateCurrentAbilities();
        ManageChangeAbilityButton();
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

    public void updateCurrentAbilities()
    {
        if(GetComponent<MenusManager>().abillitiesMenu.enabled)
        {
            lbAbility.sprite = GetComponent<Player>().currentAbilities[0].abilityStats.icon;
            xAbility.sprite = GetComponent<Player>().currentAbilities[1].abilityStats.icon;
            aAbility.sprite = GetComponent<Player>().currentAbilities[2].abilityStats.icon;
            bAbility.sprite = GetComponent<Player>().currentAbilities[3].abilityStats.icon;
            yAbility.sprite = GetComponent<Player>().currentAbilities[4].abilityStats.icon;
            rbAbility.sprite = GetComponent<Player>().currentAbilities[5].abilityStats.icon;
            for(int i=0; i<6; i++)
            {
                if (GetComponent<Player>().currentAbilities[i].changeAbility)
                {
                    abilityChanging[i].gameObject.SetActive(true);
                } else
                {
                    abilityChanging[i].gameObject.SetActive(false);
                }
            }
        }
    }

    void ManageChangeAbilityButton()
    {
        if (GetComponent<MenusManager>().abillitiesMenu.enabled)
        {
            for(int i=0; i<6; i++)
            {
                if (GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>() ==
                    GetComponent<Player>().currentAbilities[i]) 
                {
                    changeAbilityButton.gameObject.SetActive(true);
                    return;
                }
                if (GetComponent<Player>().currentAbilities[i].changeAbility && 
                    (GetComponent<MenusManager>().abillitiesMenu.currentItem.GetComponent<Ability>().abilityStats.keyBindType
                    == GetComponent<Player>().currentAbilities[i].abilityStats.keyBindType))
                {
                    changeAbilityButton.gameObject.SetActive(true);
                    return;
                }
            }
            changeAbilityButton.gameObject.SetActive(false);

        }
    }

}
