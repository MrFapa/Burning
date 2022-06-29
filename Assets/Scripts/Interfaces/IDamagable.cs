public interface IDamagable
{
    int Health { get; }

    void ReceiveDamage(int damageAmount);
}
