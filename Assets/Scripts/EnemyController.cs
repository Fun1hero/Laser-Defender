using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	float health = 10f;

	public void TakeDamege (float damage){
		Debug.Log(damage);
		if (damage >= health) Destroy(gameObject); 
		else health -= damage;
	}
}
