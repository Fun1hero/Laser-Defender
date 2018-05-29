﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public GameObject laser;
	public Image healthBar;

	float health = 10f, damage = 3f;
	float startHealth;
	public float missleSpeed = 3f, missleLifeSpan = 7f;

	float timeUntilNextShot = 0.5f;
	float timeBetweenShots = 0f;

	void Start (){
		startHealth = health;
	}

	void Update (){
		timeUntilNextShot -= Time.deltaTime;
		if (timeUntilNextShot <= 0) {
			timeBetweenShots = Random.Range(4f,8f);
			InvokeRepeating ("ShootLaser", 0.00001f, timeBetweenShots);
			timeUntilNextShot = timeBetweenShots;
		} else {
			CancelInvoke ("ShootLaser");
		}
	}

	public void TakeDamege (float damage){
		if (damage >= health)
			Destroy (gameObject);
		else { 
			health -= damage;
			healthBar.fillAmount = health / startHealth;
		}
	}

	void  ShootLaser (){
		GameObject laserInstance = Instantiate(laser, transform.position, Quaternion.identity);
		laserInstance.GetComponent<LaserController>().Init(Vector2.down, damage, missleSpeed, missleLifeSpan);
	}
}
