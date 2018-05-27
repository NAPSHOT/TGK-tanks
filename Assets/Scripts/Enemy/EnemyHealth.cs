using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.

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

        // ScoreManager.score += scoreValue;

        Destroy(gameObject, 2f);
    }


    public void StartSinking()
    {
        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // The enemy should no sink.
        isSinking = true;

        // Increase the score by the enemy's score value.
        // ScoreManager.score += scoreValue;

        // After 2 seconds destory the enemy.
        Destroy(gameObject, 2f);
    }
}