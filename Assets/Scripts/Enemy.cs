﻿using UnityEngine;
using System.Collections;

public enum EnemyType // MUST MATCH LIST IN ENEMY MANAGER AND UPDATE CHAR TO ENEMY CONVERTER AND LEVELEDITOR
{
	None, // not used // also used to catch missied stuffs
	LeftRight,
	Win,
	UpDown,
	Wall,
	PlayerStart,
	Static,
};

public enum CollisionType
{
	None = 0,
	Win,
	Death,
	Block,
}

public class Enemy : MonoBehaviour
{

	public int eID;
	public string eName;
	public EnemyType eType;
	public CollisionType eColType;
	public int eRow;
	public int eCol;

	// Use this for initialization
	void Start ()
	{
		//this.transform.parent = GameScript.instance.FloorHolder.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public static EnemyType charToEnemyTypeConverter(char c)
	{
		switch (c)
		{
			case '1':
				return EnemyType.LeftRight;
			case '2': 
				return EnemyType.Win;
			case '3':
				return EnemyType.UpDown;
			case '4':
				return EnemyType.Wall;
			case '5':
				return EnemyType.PlayerStart;
			case '6':
				return EnemyType.Static;
			default:
				return EnemyType.Static;
		}
	}
	
	// called by enemy manager
	public virtual void UpdateAI()
	{

	}
}