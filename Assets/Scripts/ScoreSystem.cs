using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

	public Text scoreField;
	int score = 0;
	//FindObjectOfType<EnemyController>().onEnemyDeath += Scoring;

	void Score (int score){
		this.score += score;
		scoreField.text = this.score.ToString();
	}

	void Reset(){
		this.score = 0;
		scoreField.text = this.score.ToString();
	}
}
