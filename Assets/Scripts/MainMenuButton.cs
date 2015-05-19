﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuButton : MonoBehaviour
{
	public InputField LoginAccountUsername;
	public InputField LoginAccountPassword;
	public InputField LoginAccountPasswordRepeat;
	public InputField LoginAccountEmail;
	public GameObject LoginAccountScreen;
	public GameObject LoginMenu;
	public GameObject MainMenu;

	public void OnButtonClick()
	{
		SceneManager.instance.NextSceneName = "LevelSelect";
	}

	public void RegisterAccount()
	{

	}

	public void RegisterAccountRegister()
	{
		string username = LoginAccountUsername.text;
		string password = LoginAccountPassword.text;
		string passwordRepeat = LoginAccountPasswordRepeat.text;
		string email = LoginAccountEmail.text;
		
		if (password != passwordRepeat)
		{
			// pop up password not matching error
		}
		LoginAccountScreen.SetActive(false);
		
		PlayerIOManager.instance.Register(username,password,email,OnSimpleSuccess,OnSimpleFailure);
	}

	public void LoginAccount()
	{

	}

	public void LoginFacebook()
	{

	}

	public void LoginKongregate()
	{

	}

	public void Continue()
	{
		SceneManager.instance.NextSceneName = "LevelSelect";
	}

	public void Logout()
	{
		PlayerIOManager.instance.Logout();
		SceneManager.instance.NextSceneName = "MainMenu";
	}


	public void LoginAccountLogin()
	{
		string username = LoginAccountUsername.text;
		string password = LoginAccountPassword.text;
		LoginAccountScreen.SetActive(false);
		PlayerIOManager.instance.Login(username,password, OnSimpleSuccess, OnSimpleFailure);
	}

	void OnSimpleSuccess()
	{
		Debug.Log("MainMenuButtonLoginSuccess");
		LoginMenu.SetActive(false);
		MainMenu.SetActive(true);
	}

	void OnSimpleFailure(string s)
	{
		Debug.Log("menuerror:  "+ s);
	}
}
