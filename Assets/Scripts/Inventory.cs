using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    private List<string> _items = new List<string>();

    public void AddItem(string itemName)
    {
        _items.Add(itemName);
        Debug.Log(itemName + " added");
    }

    public bool HasItem(string itemName)
    {
        return _items.Contains(itemName);
    }
}
