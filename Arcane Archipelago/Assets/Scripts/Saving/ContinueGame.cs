using UnityEngine;
using UnityEngine.UI;

public class ContinueGame : MonoBehaviour
{
    string[] allSaves;
    GameObject[] saveList;

    public GameObject saveSlot;
    [HideInInspector] public GameObject currentSlot;
    string saveName;
    
    void OnEnable()
    {
        allSaves = SaveManager.publicSaveList.ToArray();   //gives error
        System.Array.Resize(ref saveList, allSaves.Length);
        
        for (int a = 0; a < allSaves.Length; a++)
        {
            //Make an in-game list of all current saves by
            //spawning a button for each save file
            saveList[a] = Instantiate(saveSlot);
            saveList[a].GetComponentInChildren<Text>().text = allSaves[a];
            saveList[a].transform.SetParent(transform, false);
            saveList[a].GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -30 * a - 20, 0);
            GetComponent<RectTransform>().sizeDelta = new Vector2(0, 30 * (a + 1) + 10);
        }
    }

    public void ContinueGameButton()
    {
        if (currentSlot != null)
        {
            //Load the save
            saveName = currentSlot.GetComponentInChildren<Text>().text;

            InventoryManager.Initialize();
            
            SaveManager.LoadSave(saveName);
        }
    }

    void OnDisable()
    {
        if (saveList != null)
        {
            foreach (GameObject go in saveList)
            {
                Destroy(go);
            }
        }
    }
}
