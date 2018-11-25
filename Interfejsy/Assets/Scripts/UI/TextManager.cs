﻿using System.Collections;
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

    // Use this for initialization
    void Start ()
    {
        skillPointsToSpendText.text = "Points: " + GetComponent<Player>().skillPointsToSpend.ToString();
        UpdateStats();
    }
	
	// Update is called once per frame
	void Update () {
	    skillPointsToSpendText.text = "Points: " + GetComponent<Player>().skillPointsToSpend.ToString();
        UpdateStats();
    }

    void UpdateStats()
    {
        statPointsToSpendText.text = GetComponent<Player>().statPointsToSpend.ToString();
        strenght.text = "Strenght:\t" + GetComponent<Player>().stats[0].ToString();
        agility.text = "Agility:\t" +  GetComponent<Player>().stats[1].ToString();
        intelligence.text = "Intelligence:\t" +  GetComponent<Player>().stats[2].ToString();
        charisma.text = "Charisma:\t" +  GetComponent<Player>().stats[3].ToString();
    }
}
