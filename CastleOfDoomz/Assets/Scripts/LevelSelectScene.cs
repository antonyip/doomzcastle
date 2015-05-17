using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectScene : MonoBehaviour {

	public GameObject LevelSelectButtonHolder;
	public GameObject LevelSelectButtonPrefab;
	public int NumOfLevelsRow;
	public int NumOfLevelsCol;

	// Use this for initialization
	void Start ()
	{
		int gridSpace = 5;
		int offsetGrid = (int)LevelSelectButtonPrefab.GetComponent<RectTransform>().rect.width;
		Vector3 startPoint = new Vector3(-(offsetGrid + gridSpace) * (int)(NumOfLevelsRow/2), (offsetGrid + gridSpace)*(int)(NumOfLevelsCol/2),0);

		for (int row = 0; row < NumOfLevelsRow; row++) {
			for (int col = 0; col < NumOfLevelsCol; col++) {
				GameObject go = Instantiate(LevelSelectButtonPrefab) as GameObject;
				go.transform.SetParent(LevelSelectButtonHolder.transform);
				go.transform.localScale = Vector3.one;
				go.transform.localPosition = startPoint + new Vector3(col*(offsetGrid+gridSpace),-row*(offsetGrid+gridSpace),0);
				go.transform.GetChild(0).GetComponent<Text>().text = ((NumOfLevelsRow*row+col)+1).ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
}
