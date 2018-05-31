using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	public Text scoreField;
	public static int score = 0;
	EnemySpawner enemySpawner;
	EnemyController enemyProp;

	void Start (){
		score = 0;
		enemySpawner = FindObjectOfType<EnemySpawner>();
		enemySpawner.onEnemySpawn += AssignOnDeath;
	}

	void Score (int _score){
		score += _score;
		scoreField.text = score.ToString();
	}

	void Reset(){
		score = 0;
		scoreField.text = score.ToString();
	}

	void AssignOnDeath (GameObject enemy){
		enemyProp = enemy.GetComponent<EnemyController>();
		enemyProp.onEnemyDeath += Score;
	}
}
