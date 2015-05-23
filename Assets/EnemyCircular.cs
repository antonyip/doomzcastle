using UnityEngine;
using System.Collections;

public class EnemyCircular : Enemy
{
	int State = 0;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// called by enemy manager
	public override void UpdateAI()
	{
		if (State == 0)
		{
			eCol += 1;
			if (eCol > GameScript.maxCol -1)
				eCol = 0;
			++State;
		}
		else if (State == 1)
		{
			eRow += 1;
			if (eRow > GameScript.maxRow-1)
				eRow = 0;
			++State;
		}
		else if (State == 2)
		{
			eCol -= 1;
			if (eCol < 0)
				eCol = GameScript.maxCol-1;
			++State;
		}
		else if (State == 3)
		{
			eRow -= 1;
			if (eRow < 0)
				eRow = GameScript.maxRow-1;
			State = 0;
		}
	}
}
