using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	float speed = 3f, velocity = 1f;
	float width = 11f, height = 5f;
	float spawnDelay = 1.5f;
	float screenHalfWifthInWorldUnit;

	void Start (){
		screenHalfWifthInWorldUnit = LevelManager.screenHalfWifthInWorldUnit - width/2f;
		
		SpawnUntillFull();
	}

	void FixedUpdate (){

		if (transform.position.x < -screenHalfWifthInWorldUnit)
			velocity *= -1;
		else if (transform.position.x > screenHalfWifthInWorldUnit)
			velocity *= -1;

		transform.Translate(Vector2.right * Time.deltaTime * velocity * speed);
	}

	void Update () {
		if(AllMembersAreDead()) SpawnUntillFull();
	}

	void OnDrawGizmos (){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	void SpawnUntillFull (){
		Transform freePosition = NextFreeposition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		if (NextFreeposition()) Invoke("SpawnUntillFull", spawnDelay);
	}

	bool AllMembersAreDead (){
		foreach(Transform childPosition in transform){
			if (childPosition.childCount > 0) return false; 
		}
		return true;
	}

	Transform NextFreeposition (){
		foreach (Transform childPosition in transform){
			if (childPosition.childCount == 0) return childPosition;
		}
		return null;
	}
}
