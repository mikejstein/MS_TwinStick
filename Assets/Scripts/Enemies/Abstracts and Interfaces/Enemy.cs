using UnityEngine;
using System.Collections;
using System;

/*
 * Abstract base class for an enemy.
*/
abstract public class Enemy : MonoBehaviour {

    public GameObject target;
    protected IEnemyMovement movement;
    protected Action<Vector3> inRange;

    // Use this for initialization
    protected void Start () {
        movement = GetComponent<IEnemyMovement>(); //get our movement component
        movement.inRange += InRange; //
        movement.outRange += OutRange;
        SetTarget(GameObject.FindGameObjectWithTag("Player")); //cache a reference to our target. On start, it's assumed to be the player
	}
	
	// Update is called once per frame
	void Update () {
        if (movement != null)
        {
            movement.SetTarget(target.transform.position); // every frame, give my move component the new player location
        }
	}

    /*
     * Changes this enemy's target. 
     */
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }


    /*
     * Called by Movement to tell me that I have either moved in or out of range of an attack
     */
    public abstract void InRange(Vector3 target);
    public abstract void OutRange();

}
