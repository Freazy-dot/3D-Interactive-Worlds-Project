using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField]protected float attackCooldown;
    [SerializeField]protected float attackCooldownDuration;
    [SerializeField]protected float specialCooldown;
    [SerializeField]protected float specialCooldownDuration;
    [SerializeField]protected float armor;
    [SerializeField]protected float health;
    [SerializeField]protected float range;
    [SerializeField]protected float attackDamage;

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
        Debug.Log("Player died.");
    }
}
