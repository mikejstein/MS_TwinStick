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
            CallInRange(target);
        }
        assignTarget();
    }

    protected override void outsideBehavior()
    {
        if (inRangeStatus == true)
        {
            inRangeStatus = false;
            CallOutRange();
        }
        assignTarget();
    }

    protected override void avoidBehavior()
    {
        assignTarget();
    }

    private void assignTarget()
    {
        target = playerLocation; //this enemy ALWAYS targets the player, no matter what
    }
}
