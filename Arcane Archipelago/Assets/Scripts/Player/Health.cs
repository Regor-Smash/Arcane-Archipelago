using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Slider healthBar;
    CharacterSheet stats;
    SpriteRenderer sprite;
    GameObject deathMark;

    public int maxHealth { get; private set; }
    public float currentHealth { get; private set; }
    public void SetHealth(int health)
    {
        if (health > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = health;
        }
    }

    bool hasStarted = false;

    void Start()
    {
        if (!hasStarted)
        {
            Initialize();
        }
    }

    void Initialize()
    {
        sprite = GetComponent<SpriteRenderer>();
        stats = GetComponent<PersonalManager>().characterStats;
        healthBar = EffectManager.GetEffectMang().GetComponentInChildren<Slider>();
        if (healthBar == null)
        {
            Debug.LogError("No health bar found!", this);
        }
        hasStarted = true;

        maxHealth = stats.health;
        FullHeal(); //For now
    }

    public void FullHeal()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        //Debug.Log("For " + gameObject.name + ": Current=" + currentHealth + ", Damage=" + damage);
        currentHealth -= damage;

        if (currentHealth > 0)
        {
            sprite.color = Color.red;
            Invoke("ResetDamageEffects", 0.1f);

            UpdateHealthBar();
        }
        else
        {
            Die();
        }
    }

    void ResetDamageEffects()
    {
        sprite.color = Color.white;
    }

    public void UpdateHealthBar()
    {
        if (!hasStarted)
        {
            Initialize();
        }

        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Die()
    {
        Debug.Log(gameObject.name + "has died!");
        deathMark = (GameObject)Instantiate(Resources.Load("Characters/Death Marker"), transform.position, transform.rotation);
        transform.SetParent(deathMark.transform, true);
        if (transform.GetComponentInChildren<Camera>())
        {
            transform.GetComponentInChildren<Camera>().gameObject.transform.SetParent(deathMark.transform, false);
        }
        gameObject.SetActive(false);
    }
}
