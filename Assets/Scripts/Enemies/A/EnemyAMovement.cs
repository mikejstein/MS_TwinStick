using UnityEngine;
using System.Collections;

public class EnemyAMovement : EnemyMovement {

    public void ChangeSpeed(float newSpeed)
    {
        agent.speed = newSpeed;
    }

    protected override void RangeCheck()
    {
        if (agent.remainingDistance <= attackRange) // Tell my delegate that I'm in range.
        {
            if (inRangeStatus == false)
            {
                inRangeStatus = true;
                CallInRange(target);
            }
        } else if ((agent.remainingDistance > attackRange) && (inRangeStatus == true))
        {
            inRangeStatus = false;
            CallOutRange();
        }
    }
}
