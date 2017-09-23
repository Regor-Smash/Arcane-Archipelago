using UnityEngine;

public class PersonalManager : MonoBehaviour
{
    public bool isActiveChar { get; private set; }
    public CharacterSheet characterStats;

    private void Awake()
    {
        CharacterManager.ChangedActiveCharacter += CharacterChanged;
    }

    public void CharacterChanged(GameObject activeChar)
    {
        if (activeChar == gameObject)
        {
            //Activate character
            isActiveChar = true;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
            GetComponent<Health>().UpdateHealthBar();
        }
        else
        {
            //Deactivate character
            isActiveChar = false;
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    private void OnDestroy()
    {
        CharacterManager.ChangedActiveCharacter -= CharacterChanged;
    }
}
