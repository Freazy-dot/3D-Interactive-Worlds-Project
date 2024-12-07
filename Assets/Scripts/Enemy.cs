using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected int health = 100;
    [SerializeField]protected int speed;
    [SerializeField]protected int range;
    [SerializeField]protected int baseDamage;
    [SerializeField]protected int attackCooldown;
    [SerializeField]protected int attackCooldownDuration;
    [SerializeField]protected int specialCooldown;
    [SerializeField]protected int armor; 
    // damage reduction; 100 armor = base damage; 50 armor = base damage / 0.5; 150 armor = base damage / 1.5
   
    public abstract void Attack();

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

    protected virtual void Die()
    {
        Debug.Log($"{this.name} died.");
        Destroy(gameObject);
    }
}
