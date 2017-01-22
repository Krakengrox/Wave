using UnityEngine;
using System.Collections.Generic;


public class ItemManager
{
    #region variables


    List<Transform> items = null;


    Item item = null;


    #endregion

    public ItemManager(List<Transform> items)
    {
        this.items = items;
        CreatedItems();
    }

    void CreatedItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            item = new Item(items[i].gameObject);
        }
    }

}


