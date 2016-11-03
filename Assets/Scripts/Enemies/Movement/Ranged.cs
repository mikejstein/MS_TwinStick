using UnityEngine;
using System.Collections;

public class Ranged : EnemyMovement {
    Vector3 avoidLocation;


    /*
     * Smooths out looking at a target, so we aren't instantaniously rotating
     */
    private void LerpLookAt(Vector3 destination)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(destination - transform.position), turnSpeed);

    }

    protected override void avoidBehavior()
    {
        Vector3 toPlayer = playerLocation - gameObject.transform.position; //Get the direction to my player
        avoidLocation = transform.position + toPlayer * -1 * avoidRange; // Find my 'run to' point
        NavMeshHit hit;
        NavMesh.SamplePosition(avoidLocation, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable")); //have the navmesh find the closest point on the navmesh that matches my moveto vector.
        target = avoidLocation; //set my target to my 'run to' points
        LerpLookAt(target); //make sure I'm looking at my 'run to' point
        CallOutRange(); //I don't want to shoot, so tell my range delegate that I'm out of range
    }

    protected override void outsideBehavior()
    {
        target = playerLocation; //my target is the player location
        LerpLookAt(target); //look at my target
        CallOutRange(); //I'm out of range
    }

    protected override void insideBehavior()
    {
        target = gameObject.transform.position; //my target is my location
        LerpLookAt(playerLocation); //look at the player

        //check to see if target is within a cone of visibility
        // Hooray for linear algebra - dot product will tell the orientiation of player to me : 0 is 90 degree, 1 is in front, -1 is behind
        // So, as long as I'm greater than 0.5, i'm in the right spot.
        Vector3 toPlayer = playerLocation - gameObject.transform.position; //Get the direction to my payer
		float dotProduct = Vector3.Dot(toPlayer, gameObject.transform.forward.normalized);


		Debug.Log ("WHAT UP DOT PRODUCT?!?!?");
		Debug.Log (dotProduct);
        if (dotProduct > 0.5)
        {
            CallInRange(playerLocation);
        }
    }
}
