using UnityEngine;
using System.Collections;

public class SceneManager: MonoBehaviour {

	public static SceneManager instance;

	public string CurrentSceneName;
	public string PrevSceneName;
	public string NextSceneName;

	public enum GameMode
	{
		GameMode,
		EditorMode
	}

	public static GameMode CurrentGameMode;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		CurrentSceneName = Application.loadedLevelName;
		NextSceneName = Application.loadedLevelName;
		PrevSceneName = "Null";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (NextSceneName != CurrentSceneName)
		{
			// Fade and stuffs
			PrevSceneName = CurrentSceneName;
			CurrentSceneName = NextSceneName;
			GoToScene(NextSceneName);
		}
	}

	public void GoToScene(string SceneName)
	{
		// TODO:: TRANSITIONS
		NextSceneName = SceneName;
		Application.LoadLevel(SceneName);
	}
}
