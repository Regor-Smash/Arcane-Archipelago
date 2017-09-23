public interface AttackInterface
{
    float damage { get; }
    float range { get; }
    float fireRate { get; }
    float lastAttack { get; }
    bool canAttack { get; }

    void Attack();
}
