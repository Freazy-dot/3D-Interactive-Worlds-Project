using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected float health;
    [SerializeField]protected float speed;
    [SerializeField]protected float range;
    [SerializeField]protected float baseDamage;
    [SerializeField]protected float attackCooldown;
    [SerializeField]protected float attackCooldownDuration;
    [SerializeField]protected float specialCooldown;
    [SerializeField]protected float armor;
   
    public abstract void Attack();

    public void TakeDamage(float damage)
    {
        health -= damage - armor;

        if(health <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        Debug.Log($"{this.name} died.");
        Destroy(gameObject);
    }
}
