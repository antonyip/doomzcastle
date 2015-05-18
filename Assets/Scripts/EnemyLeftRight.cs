using UnityEngine;
using System.Collections;

public class EnemyLeftRight : Enemy
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
			eCol += 1;
			if (eCol > GameScript.maxCol -1)
				eCol = 0;
			jumped = false;
		}
		else
		{
			eCol -= 1;
			if (eCol < 0)
				eCol = GameScript.maxCol-1;
			jumped = true;
		}
	}
}
