using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{

    [SerializeField] private Image lbAbility;
    [SerializeField] private Image xAbility;
    [SerializeField] private Image aAbility;
    [SerializeField] private Image bAbility;
    [SerializeField] private Image yAbility;
    [SerializeField] private Image rbAbility;

    [SerializeField] private Slider sliderHp;
    [SerializeField] private Slider sliderMana;

    [SerializeField] public Slider healBar;

    private bool showLevelPopup = true;
    private float levelPopupAlpha = 0.5f;

    public void showLevelUpPopup()
    {
        showLevelPopup = true;
        levelPopupAlpha = 0.5f;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.Find("GameManagers").GetComponent<Player>();

        if (player)
        {
            lbAbility.sprite = player.currentAbilities[0].abilityStats.icon;
            xAbility.sprite = player.currentAbilities[1].abilityStats.icon;
            aAbility.sprite = player.currentAbilities[2].abilityStats.icon;
            bAbility.sprite = player.currentAbilities[3].abilityStats.icon;
            yAbility.sprite = player.currentAbilities[4].abilityStats.icon;
            rbAbility.sprite = player.currentAbilities[5].abilityStats.icon;


            float mana = (float)player.mana;
           

            sliderHp.value = (float)player.hp;
            sliderMana.value = (float)player.mana;
        }

        // Dismissable popup
        {
            var popup = GameObject.Find("popup_levelUp").GetComponent<Image>();

            if (showLevelPopup)
            {
                if (player.skillPointsToSpend > 0)
                {
                    popup.enabled = true;
                }

                if (levelPopupAlpha > 0.0f)
                {
                    levelPopupAlpha -= Time.deltaTime * (0.5f / 5.0f);

                    Color clr = GameObject.Find("popup_levelUp").GetComponent<Image>().color;
                    clr.a = levelPopupAlpha;
                    GameObject.Find("popup_levelUp").GetComponent<Image>().color = clr;
                }
            }       
        }
    }
};
