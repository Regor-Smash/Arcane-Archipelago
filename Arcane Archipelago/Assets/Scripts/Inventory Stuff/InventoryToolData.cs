using UnityEngine;

[CreateAssetMenu(fileName = "Inv Tool", menuName = "Inventory/Add Tool", order = 1)]
public class InventoryToolData : InventoryItemData
{
    public enum ToolTypes { Axe, Pick }
    public ToolTypes toolType;

    public int toolLevel;
    public int uses;    //durability in number of uses
}
