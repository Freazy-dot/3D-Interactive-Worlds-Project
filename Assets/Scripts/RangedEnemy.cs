using UnityEngine;


public class RangedEnemy : Enemy
{
private GameObject[] players;
private GameObject target;
private float targetUpdateCooldown = 4.0f;
private float targetUpdateTimer;

    private new void Start() 
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players) {
            Debug.Log(player.name);
        }

        if (players == null) {
            Debug.LogError("No players found");
        }

            if (target == null) {
            target = players[Random.Range(0, players.Length)];
        }

        base.Start();
    }

    private void FixedUpdate() 
    {
        if (this.isDead) return;

        if (attackCooldown > 0) {
            attackCooldown -= Time.deltaTime;
        }

        CheckForPlayer();
        MoveTowardsPlayer();

        targetUpdateTimer -= Time.deltaTime;
        if (targetUpdateCooldown <= 0) {
            targetUpdateTimer = targetUpdateCooldown;
            UpdateTarget();
        }
    }

    private void UpdateTarget()
    {
        foreach (GameObject player in players) {
            float distance = Vector3.Distance(this.transform.position, player.transform.position);
            if (distance < Vector3.Distance(this.transform.position, target.transform.position)) {
                target = player;
            }
        }
    }

    public override void Attack()
    {
        Debug.Log("rangedEnemy Attacks");
        target.GetComponent<Player>().TakeDamage(baseDamage);
    }

     private void CheckForPlayer()
     {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        if (distance < range && attackCooldown <= 0)
        {
            Attack();
            attackCooldown = attackCooldownDuration;
        }
     }

     public void MoveTowardsPlayer()
     {
        float distance = Vector3.Distance(this.transform.position, target.transform.position);
        if (distance > range) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
     }
}

