using UnityEngine;

public class SaveGameTrigger : MonoBehaviour
{
    public Color saveHighlight;
    public GameObject activeParticles;
    SpriteRenderer sprite;

    public void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sprite.color = saveHighlight;
            activeParticles.SetActive(true);

            if (Input.GetButtonDown("Interact"))    //If the player is standing on this and interacts with this
            {
                //Save game
                //Add a save effect
                SaveManager.Save();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sprite.color = Color.white;
            activeParticles.SetActive(false);
        }
    }
}
