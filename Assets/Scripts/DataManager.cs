using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Google2u;

public class DataManager : MonoBehaviour {

	public static DataManager instance;
	public LevelData selectedLevel;

	public List<LevelData> listOfLevels;
	public List<Sprite> listOfFloorTiles;
	public List<Sprite> listOfBackgrounds;
	public List<Sprite> listOfPlayers;
	
	void Awake()
	{
		selectedLevel = new LevelData();
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		selectedLevel.LoadLevel(1);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

}
