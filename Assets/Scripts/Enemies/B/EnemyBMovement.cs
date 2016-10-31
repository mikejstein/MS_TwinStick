using UnityEngine;
using System.Collections;

public class EnemyBMovement : EnemyMovement {
    Vector3 playerLocation;
    public float avoidRange; //If the enemy gets this close, run away!


    /*
     * Smooths out looking at a target, so we aren't instantaniously rotating
     */
    private void LerpLookAt(Vector3 destination)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(destination - transform.position), turnSpeed);

    }
    // Update is called once per frame
    protected override void RangeCheck()
    {
        //If I'm too close to the player
        Vector3 toPlayer = playerLocation - gameObject.transform.position;
        if (toPlayer.magnitude < avoidRange)
        {
            //pick somewhere else i can run from! I want move away from the player. 
            //get the vector from me to the player
            //Convert the above vector to my 'move to vector:
            //1. Get the inverse by multiplying by 1 - intead of pointing towards the player, it points away
            //2. Give the vector a magnitude - in this case, the avoid ranges
            //3. Add it to my existing position.
            Vector3 moveTo = transform.position + toPlayer * -1 * avoidRange;
            NavMeshHit hit;
            NavMesh.SamplePosition(moveTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable")); //have the navmesh find the closest point on the navmesh that matches my moveto vector.
            target = moveTo;
            LerpLookAt(target);
            CallOutRange();
        }
        else if (toPlayer.magnitude > attackRange) //If I'm outside attack range
        {
            target = playerLocation;
            LerpLookAt(target);
            CallOutRange();
        }
        else if (toPlayer.magnitude <= attackRange) //If I'm inside attack range
        {
            target = gameObject.transform.position;
            LerpLookAt(playerLocation);

            //check to see if target is within a cone of visibility
            // Hooray for linear algebra - dot product will tell the orientiation of player to me : 0 is 90 degree, 1 is in front, -1 is behind
            // So, as long as I'm greater than 0.5, i'm in the right spot.
            float dotProduct = Vector3.Dot(toPlayer, gameObject.transform.forward.normalized);
            if (dotProduct > 0.5)
            {
                CallInRange(playerLocation);
            }
        }
        agent.SetDestination(target);
        
    }

    public override void SetTarget(Vector3 newTarget)
    {
        playerLocation = newTarget;

    }
}
