using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RangedPlayerAttributes : Player
{
    public InputActionAsset inputActions;
    private InputAction attackAction;
    private InputAction specialAction;
    private Animator animator;
    [SerializeField] protected GameObject specialEffect;
    private void Awake()
    {
        animator = transform.Find("Wand").GetComponent<Animator>();
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
            normalAttack();
            attackCooldown = Time.time + attackCooldownDuration;
          
        }
        if (specialAction.triggered && Time.time > specialCooldown)
        {
            Special();
            specialCooldown = Time.time + specialCooldownDuration;
        }
    }


    private void normalAttack()
    {
        animator.SetBool("Attack", true);
        Debug.Log("ranged attack");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Debug.DrawRay(transform.position, transform.forward * range, Color.red, 1.0f);
            // Check if the object hit has an Enemy component
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Apply damage to the enemy
                ApplyDamage(enemy, (int)attackDamage);
                Debug.Log("Enemy hit");
            }
        }

        animator.SetBool("Attack", false);
    }

    private void Special()
    {
        Debug.Log("special attack");

        int numberOfRays = 24;
        float angleStep = 360.0f / numberOfRays;
        Instantiate(specialEffect, transform.position, Quaternion.Euler(90, 0, 0));

        for (int i = 0; i < numberOfRays; i++) {
            float angle = i * angleStep;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * transform.forward;
            Debug.DrawRay(transform.position, direction * range, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, range)) {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null) {
                    ApplyDamage(enemy, (int)attackDamage * 2);
                    Debug.Log("Enemy hit");
                }
            }
        }
    }

    private void ApplyDamage(Enemy enemy, int damage)
    {
        enemy.TakeDamage((int)damage);
        Debug.Log("Enemy hit.");
    }

}
