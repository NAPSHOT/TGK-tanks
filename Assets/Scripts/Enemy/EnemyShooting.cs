using UnityEngine;
using UnityEngine.UI;

public class EnemyShooting : MonoBehaviour
{
	public Rigidbody m_Shell;                  
	public Transform m_FireTransform;
    public float DistanceToFire = 40.0f;
	public float LaunchForce = 10.0f;        
	public float TimeToShoot = 7.0f;

    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;
    Transform turretRotation;
    private float coolDownTimer;
	private bool canFire;  


	private void Start ()
	{
		coolDownTimer = 0;
	}

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update ()
	{
		if (coolDownTimer < TimeToShoot) {
			coolDownTimer += Time.deltaTime;
		}
		else{
			canFire = true;
		}

        float distance = Vector3.Distance(transform.position, player.position);

        if (playerHealth.currentHealth > 0 && distance < DistanceToFire && canFire == true)
		{
			Fire();
		}
	}


	private void Fire ()
	{
		canFire = false;
		coolDownTimer = 0;

		Rigidbody shellInstance =
			Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
		shellInstance.velocity = LaunchForce * m_FireTransform.forward;
        shellInstance.rotation = gameObject.transform.rotation;
	}
}