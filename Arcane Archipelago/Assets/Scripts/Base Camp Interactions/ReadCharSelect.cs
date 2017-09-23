using UnityEngine;
using UnityEngine.UI;

public class ReadCharSelect : MonoBehaviour
{
    public int storyIndex;
    ExitCampMenuManager exitMenuMang;
    GameObject lockSprite;

    void Awake()
    {
        exitMenuMang = GetComponentInParent<ExitCampMenuManager>();
        lockSprite = transform.Find("Locked").gameObject;
    }

    void OnEnable()
    {
        if (storyIndex > SaveManager.currentData.storyCharUnlocks)
        {
            //Disable button
            GetComponent<Button>().interactable = false;
            transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
            lockSprite.SetActive(true);
        }
        else
        {
            //Enable button
            GetComponent<Button>().interactable = true;
            transform.GetChild(0).GetComponent<Image>().color = Color.white;
            lockSprite.SetActive(false);

            //and load current squad
            for (int a = 0; a < CharacterManager.squadPrefabs.Length; a++)
            {
                //Debug.Log ("STUFF");
                if (CharacterManager.squadPrefabs[a].name == GetComponentInChildren<StringHolder>().text)
                {
                    //Debug.Log ("Loading "+ GetComponentInChildren<StringHolder> ().text + " to slot #" + a.ToString ());
                    exitMenuMang.ChooseChar(a, gameObject);
                }
            }
        }
    }

    public void ReadCharacter()
    {
        //Debug.Log ("Character '"+ charName +"' selected");
        exitMenuMang.currentChar = gameObject;
    }
}
