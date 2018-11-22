using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int hp = 100;
    public int mana = 200;
    public List<Ability> abilities;
    static Player myInstance; 

    public static Player Instance
    {
        get
        {
            if (myInstance == null)
            {
                GameObject go = new GameObject();
                myInstance = go.AddComponent<Player>();
            }
            return myInstance;
        }
    }
    // Use this for initialization
    void Start () {
        abilities = new List<Ability>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
