using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour {

	public Text scoreField;
	
	// Use this for initialization
	void Start () {
		scoreField.text = ScoreSystem.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
