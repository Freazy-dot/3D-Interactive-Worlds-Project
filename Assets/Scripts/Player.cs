using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField]protected float attackCooldown;
    [SerializeField]protected float attackCooldownDuration;
    [SerializeField]protected float specialCooldown;
    [SerializeField]protected float specialCooldownDuration;
    [SerializeField]protected float armor;
    [SerializeField]protected float health;
    [SerializeField]protected float range;
    [SerializeField]protected int attackDamage;

    public virtual void TakeDamage(int damage)
    {
        if (armor <= 0){
            health -= damage * 2;
        }

        else {
            damage = (int)Math.Round(damage * (double)(2 - (100.0 / armor)));
            health -= damage > 0 ? damage : 0;
        }

        Debug.Log($"{this.name} took {damage} damage, {health} health remaining.");

        if (health <= 0) {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died.");
    }
}
