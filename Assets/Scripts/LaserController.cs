using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public float speed = 8, lifeSpan = 3.0f;

	public float damage;
	Vector2 direction = Vector2.zero;

	void Start () {
	 	Destroy(gameObject, lifeSpan);
	}

	// Update is called once per frame
	void Update () {
		transform.GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void OnTriggerEnter2D(Collider2D collider){
		EnemyController enemy = collider.GetComponent<EnemyController>();
		PlayerController player = collider.GetComponent<PlayerController>();

		//string colliderLayer = LayerMask.LayerToName(collider.gameObject.layer);
//		Debug.Log(colliderLayer);
//		Debug.Log("Log " + LayerMask.LayerToName(9));
//		Debug.Log("Log " + LayerMask.LayerToName(8));
		if (enemy && enemy.gameObject.layer != gameObject.layer){
			enemy.TakeDamege(damage);
			Destroy(gameObject);
		}

		if (player && player.gameObject.layer != gameObject.layer){
			player.TakeDamege(damage);
			Destroy(gameObject);
		}
	}


	public void Init (Vector2 direction, float damage, float speed, float lifeSpan){
		this.direction = direction;
		this.damage = damage;
		this.speed = speed;
		this.lifeSpan = lifeSpan;
	}
}
