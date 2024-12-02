using UnityEngine;

public class MeleePlayerAttributes : PlayerAttributes
{
    private string attackButton = "Attack";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(attackButton) && Time.time > attackCooldown)
        {
            meleeAttack();
            attackCooldown = Time.time + attackCooldownDuration;
            Debug.Log("Melee attack");
        }

    }

    private void meleeAttack()
    {

        // Perform a raycast to check for enemies in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // Visualize the raycast in the Scene view
            Debug.DrawRay(transform.position, transform.forward * range, Color.red, 1.0f);
            // Check if the object hit has an Enemy component
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
            // Apply damage to the enemy
            ApplyDamage(enemy);
            Debug.Log("Enemy hit");
            }
        }
    }
    private void meleeSpecial()
    {
        // Special attack logic
    }

    private void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(attackDamage);
        Debug.Log("Enemy hit.");
    }

}
