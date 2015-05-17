using UnityEngine;
using System.Collections;

public class EnemyUpDown : Enemy
{
	
	bool jumped = false;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// called by enemy manager
	public override void UpdateAI()
	{
		if (jumped)
		{
			eRow += 1;
			if (eRow > GameScript.maxRow -1)
				eRow = 0;
			jumped = false;
		}
		else
		{
			eRow -= 1;
			if (eRow < 0)
				eRow = GameScript.maxRow-1;
			jumped = true;
		}
	}
}
