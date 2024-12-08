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
   
    [SerializeField]protected GameObject deathEffect;
    protected bool isDead = false;
    private int accumulatedDamage;

    public abstract void Attack();

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        accumulatedDamage += damage;

        if (armor <= 0){
            health -= damage * 2;
        }

        else {
            damage = (int)Math.Round(damage * (double)(200.0 / (100.0 + armor))); // magic
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
        isDead = true;
        Points.Instance.AddPoints(accumulatedDamage);
    /* 
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogWarning("No Rigidbody component found.");
            Destroy(this.gameObject);
            return;
        }

        rb.constraints = RigidbodyConstraints.None;
    */

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        Collider collider = GetComponent<Collider>();

        if (collider == null || renderer == null) {
            Debug.LogWarning("No Collider or MeshRenderer component found.");
            Destroy(this.gameObject);
            return;
        }

        renderer.enabled = false;
        collider.enabled = false;

        if (deathEffect == null) {
            Destroy(this.gameObject);
            Debug.LogWarning("No deathEffect GameObject found.");
            return;
        }

        ParticleSystem.ShapeModule shape = deathEffect.GetComponent<ParticleSystem>().shape;
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        shape.mesh = meshFilter.sharedMesh;
        deathEffect.GetComponent<ParticleSystemRenderer>().material = renderer.sharedMaterial;

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(this.gameObject, 6.0f);
    }
}
