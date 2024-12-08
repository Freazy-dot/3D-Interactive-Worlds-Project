using UnityEngine;


public class meleeEnemy : Enemy
{
    private GameObject meleePlayer;


    private new void Start() 
    {
        meleePlayer = GameObject.FindWithTag("Player");

       base.Start();
    }
    private void Update() 
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }  
    }

    private void FixedUpdate() 
    {
        CheckForPlayer();
        MoveTowardsPlayer();
    }
    public override void Attack()
     {
        Debug.Log("meleeEnemy Attacks");

     }

     private void CheckForPlayer()
     {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < range && attackCooldown <= 0)
            {
                Attack();
                attackCooldown = attackCooldownDuration;
            }
        }
     }
     public void MoveTowardsPlayer()
     {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance > range)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
     }
}

