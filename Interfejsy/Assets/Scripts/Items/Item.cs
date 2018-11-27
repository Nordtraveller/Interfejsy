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

    public bool changeItem;

	// Use this for initialization
	void Start () {
        changeItem = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void activateChangeItem()
    {
        if (this.changeItem)
        {
            this.changeItem = false;
            return;
        }        

        for (int i = 0; i < 4; i++)
        {
            var p = GameObject.Find("GameManagers").GetComponent<Player>().currentItems[i].changeItem;

            if (p)
            {
                GameObject.Find("GameManagers").GetComponent<Player>().currentItems[i].changeItem = false;
                break;
            }
        }

        this.changeItem = true;

        /*
        for (int i = 0; i < 6; i++)
        {
            bool b = this.itemStats.type == GameObject.Find("GameManagers").GetComponent<Player>().allItems[i].itemStats.type;
            GameObject.Find("GameManagers").GetComponent<Player>().allItems[i].gameObject.SetActive(b);
        }
        */
    }

    public void ChangeItem()
    {
        Item oldItem = null;
        Item alreadyUsed = null;

        for (int i=0; i < 4; i++)
        {
            if ( GameObject.Find("GameManagers").GetComponent<Player>().currentItems[i].itemStats.itemName == this.name)
            {
                alreadyUsed = GameObject.Find("GameManagers").GetComponent<Player>().currentItems[i];
            }

            if ( GameObject.Find("GameManagers").GetComponent<Player>().currentItems[i].changeItem )
            {
                oldItem = GameObject.Find("GameManagers").GetComponent<Player>().currentItems[i];
            }
        }
        
        if (oldItem == null)
        {
            return;
        }

        if (oldItem.itemStats.type != this.itemStats.type)
        {
            return;
        }

        if (alreadyUsed != null)
        {
            alreadyUsed.itemStats = oldItem.itemStats;
        }

        oldItem.itemStats = itemStats;
        oldItem.changeItem = false;

        /*
        for (int i = 0; i < 6; i++)
        {           
            GameObject.Find("GameManagers").GetComponent<Player>().allItems[i].gameObject.SetActive(false);
        }
        */

        if (oldItem.itemStats.type == itemType.Sword)
        {
            GameObject.Find("EquimpentMenu").GetComponent<Grid>().currentItem = GameObject.Find("CurrentSwordItem").GetComponent<GridItem>();
        }
    }

    public string getCompleteDesciption()
    {
        string result = itemStats.itemDescription;
        if (itemStats.armor > 0)
        {
            result += ", armor: " + itemStats.armor;
        }

        if (itemStats.damage > 0)
        {
            result += ", damage: " + itemStats.damage;
        }

        return result;
    }
}
