using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	float screenHalfWifthInWorldUnit;
	float playerWidth;
	float timeUntilNextShot = 0.0f;
	float timeBetweenShots = 0.5f;
	public GameObject laser;

	public float health = 20f;
	public float damage = 5f;
	public float missleSpeed = 5f;
	public float missleLifeSpan = 2f;

	// Use this for initialization
	void Start () {
		float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWifthInWorldUnit = LevelManager.screenHalfWifthInWorldUnit + halfPlayerWidth;

		playerWidth = GetComponent<SpriteRenderer>().size.x;
	}
	
	// Update is called once per frame
	void Update (){
		MovePlayer();

		if (transform.position.x < -screenHalfWifthInWorldUnit + playerWidth)
			transform.position = new Vector2 (-screenHalfWifthInWorldUnit + playerWidth, transform.position.y);
		else if (transform.position.x > screenHalfWifthInWorldUnit - playerWidth)
			transform.position = new Vector2 (screenHalfWifthInWorldUnit - playerWidth, transform.position.y);

		
		timeUntilNextShot -= Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space) && timeUntilNextShot <= 0) {
			InvokeRepeating ("ShootLaser", 0.00001f, timeBetweenShots);
			timeUntilNextShot = timeBetweenShots;
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("ShootLaser");
		}

		
	}

	void  ShootLaser (){
		GameObject laserInstance = Instantiate(laser, transform.position, Quaternion.identity);
		laserInstance.GetComponent<LaserController>().Init(Vector2.up, damage, missleSpeed, missleLifeSpan);
	}

	void MovePlayer (){
		float input = Input.GetAxisRaw ("Horizontal");
		float velocity = speed * input;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
	}

	public void TakeDamege (float damage){
		if (damage >= health) Destroy(gameObject); 
		else health -= damage;
	}
}
