using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject LoginMenu;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("CheckLoggedIn",0.0f,5.0f);
	}

	void CheckLoggedIn()
	{
		if (PlayerIOManager.instance.LoggedIn)
		{
			MainMenu.SetActive(true);
			LoginMenu.SetActive(false);
		}
		else
		{
			LoginMenu.SetActive(true);
			MainMenu.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
