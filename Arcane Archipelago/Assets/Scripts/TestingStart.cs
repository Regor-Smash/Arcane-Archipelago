using UnityEngine;

public class TestingStart : MonoBehaviour
{
#if UNITY_EDITOR
    public GameObject[] testSquad;

    public bool newSave;
    public SaveData testData = new SaveData();

    public string[] testInv;
    public int[] testAmounts;

    void Awake()
    {
        if (CharacterManager.squadPrefabs == null)
        {
            CharacterManager.squadPrefabs = testSquad;
        }

        if (InventoryManager.invList == null)
        {
            if (testInv.Length != testAmounts.Length)
            {
                Debug.LogError("Testing resource types and amounts do not match");
                return;
            }

            InventoryManager.Initialize();
            for (int a = 0; a < testInv.Length; a++)
            {
                InventoryManager.AddInvItem(testInv[a], testAmounts[a]);
            }
        }

        if (string.IsNullOrEmpty(SaveManager.currentData.saveName))
        {
            if (newSave)
            {
                //Debug.Log ("Creating Test Save '" + testData.saveName + "'");
                SaveManager.MakeTestSave(testData);
            }
            else
            {
                //Debug.Log ("Loading Test Save '" + testData.saveName + "'");
                SaveManager.LoadSave(testData.saveName);
            }
        }
    }
#endif
}
