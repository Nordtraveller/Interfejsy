using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    public int hp = 100;
    public int mana = 200;
    public int[] stats;
    public int level = 1;
    public int statPointsSpend = 0;
    public int statPointsToSpend = 0;
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
        stats = new int[4];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUp()
    {
        level += 1;
        statPointsToSpend += 3;
    }

    public void AddToStat(int index)
    {
        if(statPointsToSpend != 0)
        {
            statPointsToSpend -= 1;
            stats[index] += 1;
        }
    }

}
