using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleePlayerAttributes : PlayerAttributes
{
    public InputActionAsset inputActions;
    private InputAction attackAction;
    private InputAction specialAction;
    private Animator animator;
    private void Awake()
    {
        animator = transform.Find("swordfix").GetComponent<Animator>();
        attackAction = inputActions.FindAction("Attack");
        specialAction = inputActions.FindAction("Interact");
    }

    private void OnEnable()
    {
        attackAction.Enable();
        specialAction.Enable();
    }

    private void OnDisable()
    {
        attackAction.Disable();
        specialAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAction.triggered && Time.time > attackCooldown)
        {
            meleeAttack();
            attackCooldown = Time.time + attackCooldownDuration;
          
        }
        if (specialAction.triggered && Time.time > specialCooldown)
        {
            meleeSpecial();
            specialCooldown = Time.time + specialCooldownDuration;
        }
    }


    private void meleeAttack()
    {
        animator.SetBool("Attack", true);
        Debug.Log("Melee attack");
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
        StartCoroutine(ChannelMeleeAttack());
        Debug.Log("Special attack coroutine started.");
    }

    private void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(attackDamage);
        Debug.Log("Enemy hit.");
    }

    private IEnumerator ChannelMeleeAttack()
    {
        int hits = 10;
        float duration = 2.0f;
        float interval = duration / hits;

        for (int i = 0; i < hits; i++)
        {
            meleeAttack();
            yield return new WaitForSeconds(interval);
            Debug.Log("Special attack hit.");
        }
    }
}
