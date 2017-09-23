using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Characters/Add Data", order = 0)]
public class CharacterSheet : ScriptableObject
{
    //name?
    //sprite?
    public int health;
    public int mana;
    public int manaRegen;
    public float speed;
    public float jumpSpeed;
    public int jumpNum;
}
