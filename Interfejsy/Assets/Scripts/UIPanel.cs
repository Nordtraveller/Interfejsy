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
        }
    }
};
