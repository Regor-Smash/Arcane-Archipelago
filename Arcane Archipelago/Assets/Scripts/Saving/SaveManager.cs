using UnityEngine;
using UnityEngine.SceneManagement;

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager //: MonoBehaviour
{
    static BinaryFormatter biForm = new BinaryFormatter();

    static FileStream file;
    static string gameSavesPath;

    static DirectoryInfo savesDirectory;
    public static List<string> publicSaveList
    {
        get
        {
            if (!hasInit)
            {
                Initialize();
            }

            List<string> tempSaves = new List<string>();
            foreach(FileSystemInfo file in savesDirectory.GetFiles())
            {
                string tempName = file.Name;
                tempSaves.Add(tempName.Remove(tempName.LastIndexOf(".")));
            }
            return tempSaves;
        }
    }
    
    public static SaveData currentData { get; private set; }

    static bool hasInit = false;
    
    public static void Initialize()
    {
        if (!hasInit)
        {
            SceneManager.sceneLoaded += LoadedScene;

            gameSavesPath = Application.persistentDataPath + "/Saves/";

            if (!Directory.Exists(gameSavesPath))
            {
                Directory.CreateDirectory(gameSavesPath);
            }
            savesDirectory = new DirectoryInfo(gameSavesPath);

            hasInit = true;
        }
    }

    public static void Save()
    {
        if (!File.Exists(gameSavesPath + currentData.saveName + ".dat"))
        {
            Debug.LogError("Save '" + currentData.saveName + "' not found. Creating a new save.");
            NewSave(currentData.saveName);
        }

        //Save data to currentData
        InventoryManager.SaveInv();
        currentData.researchTimeLeft = ResearchManager.GetTimeLeft();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            currentData.savedInScene = "Initial Crash"; //SceneManager.GetSceneByBuildIndex(1).name;
            //Debug.Log("Should have saved in: " + SceneManager.GetSceneByBuildIndex(1).name);
        }
        else
        {
            currentData.savedInScene = SceneManager.GetActiveScene().name;
            //Debug.Log("Should have saved in: " + SceneManager.GetActiveScene().name);
        }
        //Debug.Log("Saved in: " + currentData.savedInScene);

        //Create or Overwrite a save file
        file = File.Create(gameSavesPath + currentData.saveName + ".dat");
        biForm.Serialize(file, currentData);
        file.Close();
        Debug.Log("Save '" + currentData.saveName + "' has been saved");
    }

    public static void NewSave(string newName)
    {
        //Create a new save
        currentData = new SaveData();
        currentData.saveName = newName;

        //Create a temp save file for the actual Save() function to read
        file = File.Create(gameSavesPath + currentData.saveName + ".dat");
        biForm.Serialize(file, currentData);
        file.Close();

        Save();
    }

    public static void LoadSave(string tempName)
    {
        if (File.Exists(gameSavesPath + tempName + ".dat"))
        {
            file = File.Open(gameSavesPath + tempName + ".dat", FileMode.Open);
            currentData = (SaveData)biForm.Deserialize(file);   //take variables out of save data file
            file.Close();
            //Debug.Log ("Save '" + currentData.saveName + "' has loaded");

            InventoryManager.LoadInv(); //Load inventory
            //Debug.Log ("Inventory for Save '" + currentData.saveName + "' has loaded");

            SceneManager.LoadScene(currentData.savedInScene);
        }
    }

    public static void ReloadSave()
    {
        LoadSave(currentData.saveName);
    }

    public static void DeleteSave(string tempName)
    {
        if (File.Exists(gameSavesPath + tempName + ".dat"))
        {
            //Delete a save file
            File.Delete(gameSavesPath + tempName + ".dat");
        }
    }

    static void LoadedScene(Scene curScene, LoadSceneMode load)
    {
        if (curScene.buildIndex == 0)
        {
            //Debug.Log("currentData reset");
            currentData = new SaveData();
        }
    }

#if UNITY_EDITOR
    public static void MakeTestSave(SaveData testData)
    {
        currentData = testData;
        Save();
    }
#endif
}

[Serializable]
public class SaveData
{
    public string saveName;
    public string savedInScene;

    public Dictionary<string, int> savedInv = new Dictionary<string, int>();
    public List<string> unlockedCraftingRecipes = new List<string>();

    public int unlockedAreas;
    public int storyCharUnlocks;
    public int currentObjectiveIndex;
    public List<string> dialoguesRead = new List<string>(); //Stores names of dialogues (name of canvas)

    public float researchTimeLeft;
    public Dictionary<string, int> researchCompleted = new Dictionary<string, int>();	//<short character name, number completed>
}
