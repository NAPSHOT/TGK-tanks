using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startingHealth = 100;                           
	public int currentHealth; 
	public Slider healthSlider;  
	public Image damageImage;
	public GameObject gameOverImage;
	public float flashSpeed = 5f; 
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f); 


	PlayerMove playerMove;                              
	PlayerShooting shooting;
    PlayerTurretRotation playerTurretRotation;
	bool isDead;     
	bool damaged; 


	void Awake ()
	{

		playerMove = GetComponent <PlayerMove> ();
		shooting = GetComponentInChildren <PlayerShooting> ();
        playerTurretRotation = GetComponentInChildren <PlayerTurretRotation> ();

		gameOverImage.SetActive (false);

		
	}


    private void Start()
    {
        currentHealth = startingHealth;
    }


    void Update ()
	{
		
		if(damaged)
		{	
			damageImage.color = flashColour;
		}
		else
		{

			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}


	public void TakeDamage (int amount)
	{

		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
		
	void Death ()
	{
		isDead = true;
		gameOverImage.SetActive (true);
		playerMove.enabled = false;
		shooting.enabled = false;
        playerTurretRotation.enabled = false;
	}       
}
