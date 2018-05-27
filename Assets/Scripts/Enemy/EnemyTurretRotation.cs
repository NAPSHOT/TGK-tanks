using UnityEngine;

public class EnemyTurretRotation : MonoBehaviour
{
    public float TurnSpeed = 90f;            // How fast the tank turns in degrees per second.

    Transform player;               // Reference to the player's position.

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 difference = player.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;

        Quaternion qTo = Quaternion.Euler(-90.0f, 0.0f, rotationZ);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qTo, TurnSpeed * Time.deltaTime);
    }
}