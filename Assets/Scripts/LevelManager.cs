using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public int currentLevel;
	public string currentLevelName;
	public static float screenHalfWifthInWorldUnit = Camera.main.aspect * Camera.main.orthographicSize;
	public static float screenHalfHeightInWorldUnit = Camera.main.orthographicSize;

	void Awake(){
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		currentLevelName = SceneManager.GetActiveScene().name;
		//screenHalfWifthInWorldUnit = Camera.main.aspect * Camera.main.orthographicSize;
		//screenHalfHeightInWorldUnit = Camera.main.scaledPixelHeight;
		//CursorCheck();
	}

	public void LoadLevel (string name){
		SceneManager.LoadScene(name);
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
}
