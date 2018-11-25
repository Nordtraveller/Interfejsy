using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {


    [SerializeField] private Text statPointsToSpendText;

    // Use this for initialization
    void Start ()
    {
        statPointsToSpendText.text = "Points: " + GetComponent<Player>().statPointsToSpend.ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    statPointsToSpendText.text = "Points: " + GetComponent<Player>().statPointsToSpend.ToString();
    }
}
