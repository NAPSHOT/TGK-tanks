using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    Transform enemyTank;
    PlayerHealth playerHealth;      // Reference to the player's health.
    // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;// Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindWithTag("Player").transform;
        enemyTank = GameObject.FindWithTag("EnemyTank").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        // enemyHealth.currentHealth > 0 &&
        if (playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            if(Vector3.Distance(enemyTank.position, player.position) > 10.0f)
            {
                nav.isStopped = false;
                nav.SetDestination(player.position);
            }
            else
            {
                nav.isStopped = true;
            }
            
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}