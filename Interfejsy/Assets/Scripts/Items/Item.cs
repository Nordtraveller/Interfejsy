using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum itemType
{
    None,

    Sword,
    Head,
    Armor,
    Shield
}

public class Item : MonoBehaviour {

    [SerializeField] public ItemStats itemStats;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
