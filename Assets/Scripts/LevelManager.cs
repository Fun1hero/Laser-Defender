using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public int currentLevel;
	public string currentLevelName;
	public static float screenHalfWifthInWorldUnit;
	public static float screenHalfHeightInWorldUnit;


	PlayerController player;

	void Awake(){

		screenHalfWifthInWorldUnit = Camera.main.aspect * Camera.main.orthographicSize;
		screenHalfHeightInWorldUnit = Camera.main.orthographicSize;

		currentLevel = SceneManager.GetActiveScene().buildIndex;
		currentLevelName = SceneManager.GetActiveScene().name;

	}

	void Start(){
		SceneManager.sceneLoaded += SceneLoaded;
	}

	public void LoadLevel (string name){
		SceneManager.LoadScene(name);
		//SceneManager.sceneLoaded += SceneLoaded;
	}

	void SceneLoaded (Scene scene, LoadSceneMode mode){
		player = FindObjectOfType<PlayerController>();
		if (player != null)
			player.onDestroyPlayer += OnPlayerDeath;
	}

	public void QuitRequest (){
		Application.Quit();
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	void CursorCheck (){
		if (currentLevelName != "Start" && currentLevelName != "Win" && currentLevelName != "Lose") {
			Cursor.visible = false;
		} else {
			Cursor.visible = true;
		}
	}

	void OnPlayerDeath (){
		LoadLevel("End");
	}
}
