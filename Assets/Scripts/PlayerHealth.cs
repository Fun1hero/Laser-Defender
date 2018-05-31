using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public Image healthBar;

	PlayerController player;

	//AudioClip deathSound;

	float startHealth, currentHealth;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();
		startHealth = player.health;
		//deathSound = player.deathSound;
		player.onTakeDamage += HealthTrack;
		player.onDestroyPlayer += Dead;
	}
	
	// Update is called once per frame
	void Update (){
		
	}

	void HealthTrack (){
		if (player != null) {
			currentHealth = player.health;
			healthBar.fillAmount = currentHealth / startHealth;
		}
	}

	void Dead () {
		if (player != null) {
			//AudioSource.PlayClipAtPoint (deathSound, transform.position);
			healthBar.fillAmount = 0f;
		}
	}
}
