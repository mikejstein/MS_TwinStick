using UnityEngine;
using System.Collections;

public class Charge : EnemyMovement
{

    protected bool inRangeStatus = false;

    protected override void insideBehavior()
    {
        if (inRangeStatus == false)
        {
            inRangeStatus = true;
			InRange(player);
        }
        assignTarget();
    }

    protected override void outsideBehavior()
    {
        if (inRangeStatus == true)
        {
            inRangeStatus = false;
			InRange(player);
        }
		assignTarget();
    }

    protected override void avoidBehavior()
    {
		//This enemy doesn't have an avoid behavior.
		assignTarget();
    }

    private void assignTarget()
    {
		destination = player.transform.position;
    }
}
