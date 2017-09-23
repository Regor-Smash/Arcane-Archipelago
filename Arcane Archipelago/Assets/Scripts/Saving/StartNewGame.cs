using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
    public Text newSaveName;

    public GameObject[] startSquad;
    public string[] defaultInvList;

    public void StartGameButton(string startSceneName)
    {
        if (newSaveName.text != null && newSaveName.text != "")
        {
            if (SaveManager.publicSaveList.Contains(newSaveName.text))
            {
                newSaveName.color = Color.red;
                Invoke("ResetColor", 0.5f);
            }
            else
            {
                CharacterManager.squadPrefabs = startSquad;
                InventoryManager.Initialize();

                foreach (string name in defaultInvList)
                {
                    InventoryManager.AddInvItem(name, 1);
                }
                SaveManager.NewSave(newSaveName.text);

                SceneManager.LoadScene(startSceneName);
            }
        }
    }

    void ResetColor()
    {
        newSaveName.color = Color.black;
    }
}
