using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnButtonClicked()
	{
		Text s = transform.GetChild(0).GetComponent<Text>();
		int levelSelected = int.Parse(s.text);
		Debug.Log("LevelSelected: " + levelSelected);
		DataManager.instance.selectedLevel.LoadLevel(levelSelected);
		SceneManager.instance.NextSceneName = "GameLevel";
		SceneManager.CurrentGameMode = SceneManager.GameMode.GameMode;
	}
}
