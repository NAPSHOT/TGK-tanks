using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    

    //ParticleSystem hitParticles;                // Reference to the particle system that plays when the enemy is damaged.
    BoxCollider boxCollider;                    // Reference to the box collider.
    EnemyTurretRotation enemyTurretRotation;
    EnemyShooting shooting;
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.


    void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();

        enemyTurretRotation = GetComponentInChildren<EnemyTurretRotation>();
        shooting = GetComponentInChildren<EnemyShooting>();

        // Setting the current health when the enemy first spawns.
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        boxCollider.isTrigger = true;
        enemyTurretRotation.enabled = false;
        shooting.enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        ScoreManager.score += 1;

        Destroy(gameObject, 2f);
    }


    public void StartSinking()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}