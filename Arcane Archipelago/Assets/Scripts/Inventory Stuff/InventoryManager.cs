using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public static class InventoryManager
{
    //invList stores name and amount for each item
    //use LoadItemData() to access the Scriptable Object with the item's data on it
    public static Dictionary<string, int> invList { get; private set; }

    private static string itemPath;
    private static bool hasInit = false;

    //Set when an item is added or removed
    public static bool hasAxe { get; private set; }
    public static bool hasPickaxe { get; private set; }

    public static void Initialize()
    {
        if (!hasInit)
        {
            SceneManager.sceneLoaded += LoadedScene;
            invList = new Dictionary<string, int>();

            hasInit = true;
        }
    }

    public static InventoryItemData LoadItemData(string itemName)
    {
        itemPath = "Inventory Items/" + itemName;
        return (InventoryItemData)Resources.Load(itemPath);
    }

    public static void AddInvItem(string itemName, int quantity)
    {
        itemPath = "Inventory Items/" + itemName;
        if (invList.ContainsKey(itemName))
        {
            //add more of an already acquired item
            invList[itemName] += quantity;

            EffectManager.GetEffectMang().AddInvItemEffect(LoadItemData(itemName).itemSprite, quantity);
        }
        else if (Resources.Load(itemPath) != null)
        {
            //add a newly acquired item
            invList.Add(itemName, quantity);

            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                EffectManager.GetEffectMang().AddInvItemEffect(LoadItemData(itemName).itemSprite, quantity);
            }
        }
        else if (Resources.Load(itemPath) == null)
        {
            //item does not have data
            Debug.LogError("No data for " + itemName + " found at: " + itemPath);
        }
    }

    public static void RemoveInvItem(string itemName, int quantity)
    {
        if (invList.ContainsKey(itemName) && invList[itemName] - quantity >= 0)
        {
            invList[itemName] = invList[itemName] - quantity;
            if (invList[itemName] == 0)
            {
                invList.Remove(itemName);
            }
        }
        else
        {
            Debug.LogError("You do not have enough " + itemName);
        }
    }

    static void LoadedScene(Scene curScene, LoadSceneMode load)
    {
        if (curScene.buildIndex == 0)
        {
            //SaveInv();
            invList.Clear();
        }
    }

    public static void SaveInv()
    {
        SaveManager.currentData.savedInv = invList;
    }

    public static void LoadInv()
    {
        invList = SaveManager.currentData.savedInv;
    }
}
