using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
    public float DistanceToPlayer = 30.0f;
    public float DistanceToPlayerHeuristics = 10.0f;
    Transform player;               // Reference to the player's position.
    Transform enemyTank;
    PlayerHealth playerHealth;      // Reference to the player's health.
    // EnemyHealth enemyHealth;        // Reference to this enemy's health.
    float targetDistanceToPlayer;
    UnityEngine.AI.NavMeshAgent nav;// Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindWithTag("Player").transform;
        enemyTank = gameObject.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        if (playerHealth.currentHealth > 0)
        {
            float distance = Vector3.Distance(enemyTank.position, player.position);
            if(distance > DistanceToPlayer)
            {
                nav.isStopped = false;
                nav.SetDestination(player.position);
                targetDistanceToPlayer = Random.Range(DistanceToPlayer - DistanceToPlayerHeuristics, DistanceToPlayer);
            }
            else if(distance > targetDistanceToPlayer)
            {
                if(!nav.isStopped)
                {
                    nav.SetDestination(player.position);
                }
            }
            else
            {
                nav.isStopped = true;
            }
            
        }
        else
        {
            nav.enabled = false;
        }
    }
}