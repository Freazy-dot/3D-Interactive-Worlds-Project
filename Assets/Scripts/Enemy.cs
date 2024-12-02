using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected float health = 100f;
    [SerializeField]protected float speed;
    [SerializeField]protected float range;
    [SerializeField]protected float baseDamage;
    [SerializeField]protected float attackCooldown;
    [SerializeField]protected float attackCooldownDuration;
    [SerializeField]protected float specialCooldown;
    [SerializeField]protected float armor;
    public float Health => health; // Getter for health

   
    public abstract void Attack();

    public virtual void TakeDamage(float attackDamage)
    {
        float damage = attackDamage - armor;
        health -= damage > 0 ? damage : 0;

        Debug.Log($"{this.name} took {damage} damage, {health} health remaining.");

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{this.name} died.");
        Destroy(gameObject);
    }
}
