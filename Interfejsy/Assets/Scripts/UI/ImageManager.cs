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
    // Use this for initialization
    void Start () {
        setStatsActivity();
    }
	
	// Update is called once per frame
	void Update () {
        updateCurrentAbilities();
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
            //lbAbility.sprite = GetComponent<Player>().currentAbilities[0].GetComponent<Ability>().abilityStats.icon;
            //lbAbility.sprite = GetComponent<Player>().currentAbilities[0].abilityStats.icon;
        }
    }

}
