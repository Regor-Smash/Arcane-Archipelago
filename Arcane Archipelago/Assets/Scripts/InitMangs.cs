using UnityEngine;

public class InitMangs : MonoBehaviour
{
    void Awake()
    {
        SaveManager.Initialize();
        InventoryManager.Initialize();
    }
}
