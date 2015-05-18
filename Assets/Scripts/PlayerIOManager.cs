using UnityEngine;
using System.Collections;
using PlayerIOClient;
using System;

public class PlayerIOManager : MonoBehaviour {

	public static PlayerIOManager instance;

	string gameID = "doomzcastle-qyld5t9hqk6fnkeqimrgxa";
	string username = "antonyip";
	string password = "diamond";

	Client client;

	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		// need to create a register page
		//PlayerIO.QuickConnect.SimpleRegister(gameID,username,password,null,null,null,null,null,null,OnRegister);

		// used to connect
		PlayerIO.QuickConnect.SimpleConnect(gameID,username,password,null,OnConnect);
	}

	void OnRegister(Client _client)
	{
		Debug.Log("Registered");
		client = _client;
	}

	void OnConnect(Client _client)
	{
		//Debug.Log(client.ConnectUserId);
		Debug.Log("Connected");
		client = _client;
		SearchLevel();
	}

	void SearchLevel()
	{
		//client.BigDB.Load("CustomLevels","creator2",OnSearchLevel);
		client.BigDB.LoadRange("CustomLevels","creator", new object[]{"antonyip"},null,null,1000,OnSearchByName);
	}

	void OnSearchByName(DatabaseObject[] _databaseObject)
	{
		/*
		foreach (DatabaseObject DO in _databaseObject)
			Debug.Log(DO);
		*/
	}

	void OnSearchLevel(DatabaseObject _databaseObject)
	{
		string leveldata = _databaseObject.GetString("leveldata");
		Debug.Log(_databaseObject);
	}

	public void SubmitCurrentLevel()
	{
		DatabaseObject DO = new DatabaseObject();
		DO.Set("attempts",0);
		DO.Set("creator",username);
		DO.Set("fail",0);
		DO.Set("pass",0);
		DO.Set("leveldata",DataManager.instance.selectedLevel.levelData);
		string uid = username+"_"+System.DateTime.Now.Ticks;
		client.BigDB.CreateObject("CustomLevels",uid,DO,OnCreateLevelData,FailCreateLevelData);
		DebugConsole.Log("Submitted");
	}

	void CreateLevel()
	{
		DatabaseObject DO = new DatabaseObject();
		DO.Set("attempts",0);
		DO.Set("creator",username);
		DO.Set("fail",0);
		DO.Set("pass",0);
		DO.Set("leveldata","222222222");
		client.BigDB.CreateObject("CustomLevels","creator2",DO,OnCreateLevelData,FailCreateLevelData);
	}

	void OnCreateLevelData(DatabaseObject _databaseObject)
	{
		Debug.Log("Created");
	}
	
	void FailCreateLevelData(PlayerIOError _error)
	{
		Debug.Log(_error.Message);
	}
}
