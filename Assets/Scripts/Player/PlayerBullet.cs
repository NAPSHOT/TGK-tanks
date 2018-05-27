using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
	public LayerMask m_TankMask;  
	public float m_MaxDamage = 100f;  
	public float m_MaxLifeTime = 10f;
	public float m_ExplosionRadius = 5f; 


	private void Start ()
	{
		Destroy (gameObject, m_MaxLifeTime);
	}


	private void OnTriggerEnter (Collider other)
	{
		Collider[] colliders = Physics.OverlapSphere (transform.position, m_ExplosionRadius, m_TankMask);

		for (int i = 0; i < colliders.Length; i++)
		{
			Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody> ();
			if (!targetRigidbody)
				continue;
			PlayerHealth targetHealth = targetRigidbody.GetComponent<PlayerHealth> ();
            EnemyHealth enemyHealth = targetRigidbody.GetComponent<EnemyHealth>();

            if (targetHealth)
            {
                int damage = (int)CalculateDamage(targetRigidbody.position);

                targetHealth.TakeDamage(damage);
            }
			else if (enemyHealth)
            {
                int damage = (int)CalculateDamage(targetRigidbody.position);

                enemyHealth.TakeDamage(damage);
            }
            
		}
		Destroy (gameObject);
	}


	private float CalculateDamage (Vector3 targetPosition)
	{
		Vector3 explosionToTarget = targetPosition - transform.position;

		float explosionDistance = explosionToTarget.magnitude;

		float relativeDistance = (m_ExplosionRadius - explosionDistance) / m_ExplosionRadius;

		float damage = relativeDistance * m_MaxDamage;

		damage = Mathf.Max (0f, damage);

		return damage;
	}
}