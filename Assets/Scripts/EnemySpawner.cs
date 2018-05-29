using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	float speed = 3f, velocity = 1f;
	float width = 11f, height = 5f;
	float screenHalfWifthInWorldUnit;
	// Use this for initialization
	void Start (){
		//float playerWidth = transform.localScale.x / 2f;
		screenHalfWifthInWorldUnit = LevelManager.screenHalfWifthInWorldUnit - width/2f;
		
		SpawnEnemy();
	}

	void FixedUpdate (){

		if (transform.position.x < -screenHalfWifthInWorldUnit)
			velocity *= -1;
		else if (transform.position.x > screenHalfWifthInWorldUnit)
			velocity *= -1;

		transform.Translate(Vector2.right * Time.deltaTime * velocity * speed);
	}

	// Update is called once per frame
	void Update () {

		
	}

	void OnDrawGizmos (){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	void SpawnEnemy (){
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}
}
