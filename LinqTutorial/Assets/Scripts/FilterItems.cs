using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string Name;
    public int ID;
    public int Buff;
}

public class FilterItems : MonoBehaviour
{
    public List<Item> items;

    private void Start()
    {
        //see if item 3 exists
        var result = items.Any(item => item.ID == 3);
        Debug.Log("Item 3 exists? " + result);

        //print all items with buff > 20
        var newList = items.Where(item => item.Buff > 20);

        Debug.Log("Items with buff > 20");
        foreach (Item item in newList)
        {
            Debug.Log(item.Name);
        }

        //calculate the average of all buff stats
        var average = items.Average(item => item.Buff);
        Debug.Log("Average: " + average);

    }
}
