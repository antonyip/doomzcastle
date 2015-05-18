﻿using UnityEngine;
using System.Collections;
using Google2u;

public class LevelData
{

	public string levelName;
	public int level;
	public string levelData;

	// Use this for initialization
	public LevelData ()
	{
		levelName = "undefined";
		level = -1;
		levelData = "0000000020004000000000060000000010000000000000003";
	}

	// used for internal levels
	public void LoadLevel(int level)
	{
		if (level <= 8)
		{
			LevelsRow ldata = Levels.Instance.GetRow("level"+level.ToString());
			level = ldata._idint;
			levelData = ldata._leveldata;
			levelName = ldata._name;
			//Levels.Instance.GetGenRow("level"+level.ToString());
		}
		else
		{
			Levels2Row ldata2 = Levels2.Instance.GetRow("level"+level.ToString());
			level = ldata2._idInt;
			levelData = ldata2._leveldata;
			levelName = ldata2._name;
		}
	}

	// used for external levels
	public void LoadLevel(LevelData ld)
	{

	}

	// used for external levels
	public void LoadLevel(string s)
	{
		if (s.Length != 49)
		{
			Debug.Log("LevelData::String Length not right");
			return;
		}
		else
		{
			Debug.Log("LevelData: " + s);
			levelName = "LevelEditor";
			level = 99;
			levelData = s;
		}
	}
}