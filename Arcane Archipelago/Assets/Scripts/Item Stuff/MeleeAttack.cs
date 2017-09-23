using UnityEngine;

public class MeleeAttack : MonoBehaviour, AttackInterface
{
    public float damage { get; private set; }
    public float range { get; private set; }
    public float fireRate { get; private set; }
    public float lastAttack { get; private set; }
    public bool canAttack
    {
        get
        {
            if (lastAttack + fireRate > Time.time)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    void Start()
    {

    }

    public void Attack()
    {
        lastAttack = Time.time;
    }
}
