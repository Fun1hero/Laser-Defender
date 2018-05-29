using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	float speed = 8, lifeSpan = 3.0f;
	public float damage = 5f;
	// Use this for initialization
	void Start () {
	 	Destroy(gameObject, lifeSpan);
	}

	// Update is called once per frame
	void Update () {
		transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		//transform.Translate(Vector2.up * speed * Time.deltaTime);
		//if (transform.position.y > LevelManager.screenHalfHeightInWorldUnit) Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider){
		EnemyController enemy = collider.GetComponent<EnemyController>();
		if (enemy){
			enemy.TakeDamege(damage);
			Destroy(gameObject,lifeSpan);
		}
	}
}
