﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
	public void changeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
		
	public void quitGame(){
		Debug.Log ("quit!");
		Application.Quit ();
	}
}
