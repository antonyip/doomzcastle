﻿using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnButtonClick()
	{
		SceneManager.instance.NextSceneName = "LevelSelect";
	}
}
