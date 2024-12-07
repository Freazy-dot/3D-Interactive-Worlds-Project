using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]protected int health = 100;
    [SerializeField]protected int speed;
    [SerializeField]protected int range;
    [SerializeField]protected int baseDamage;
    [SerializeField]protected float attackCooldown;
    [SerializeField]protected float attackCooldownDuration;
    [SerializeField]protected float specialCooldown;
    [SerializeField]protected float specialCooldownDuration;
    [SerializeField]protected int armor; 
    // damage reduction; 100 armor = base damage; 0 armor = 2 x base damage; 200 armor = half of base damage
   
    public abstract void Attack();

    public void TakeDamage(int damage)
    {
        if (armor <= 0){
            health -= damage * 2;
        }

        else {
            damage = (int)Math.Round(damage * (double)(200.0 / (100.0 + armor)));

            health -= damage > 0 ? damage : 0;
        }

        Debug.Log($"{this.name} took {damage} damage, {health} health remaining.");

        if (health <= 0) {
            Die();
        }
    }

    protected void Die()
    {
        Debug.Log($"{this.name} died.");
        Destroy(gameObject);
    }
}
