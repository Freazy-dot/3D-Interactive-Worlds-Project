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
    [SerializeField]protected GameObject deathEffect;
    private bool isDead = false;

    public virtual void TakeDamage(int damage)
    {
        if (isDead) return;

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

    private void Die()
    {
        Debug.Log($"{this.name} died.");
        isDead = true;

    /*
        CharacterController characterController = GetComponent<CharacterController>();
        if (characterController == null) {
            Debug.LogWarning("No CharacterController component found.");
            Destroy(this.gameObject);
            return;
        }

        characterController.enabled = false;
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
