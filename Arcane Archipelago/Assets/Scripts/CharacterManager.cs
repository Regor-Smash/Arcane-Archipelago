using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //Goes on player camera

    static GameObject activeChar;
    int activeCharIndex;

    GameObject[] squad;
    public static GameObject[] squadPrefabs;
    public Vector3[] squadOffsets;
    int totalChars;

    bool hasInitialized;

    public delegate void CharacterSwitch(GameObject character);
    public static event CharacterSwitch ChangedActiveCharacter;

    void Start()
    {
        SpawnSquad();
    }

    void Update()
    {
        if (Input.GetButtonDown("Change Character") && !DialogueController.isDialogue)
        {
            ChangeActiveCharacter();
        }
        if (!hasInitialized && !DialogueController.isDialogue)
        {
            ChangeActiveCharacter();
        }
    }

    void SpawnSquad()
    {
        activeCharIndex = 0;
        totalChars = squadPrefabs.Length;
        System.Array.Resize(ref squad, totalChars);
        for (int a = 0; a < totalChars; a++)
        {
            squad[a] = (GameObject)Instantiate(squadPrefabs[a], squadOffsets[a], Quaternion.identity);
            //Debug.Log ("Spawned '" + squad[a].name + "'");
        }
        if (!DialogueController.isDialogue)
        {
            ChangeActiveCharacter();
        }
    }

    void ChangeActiveCharacter()
    {
        if (!hasInitialized)
        {
            hasInitialized = true;
        }
        activeCharIndex = activeCharIndex + (int)Input.GetAxis("Change Character");
        if (activeCharIndex > totalChars - 1)
        {
            activeCharIndex = 0;
        }
        else if (activeCharIndex < 0)
        {
            activeCharIndex = totalChars - 1;
        }

        activeChar = squad[activeCharIndex];
        transform.SetParent(activeChar.transform, false);

        ChangedActiveCharacter(activeChar);
    }
}
