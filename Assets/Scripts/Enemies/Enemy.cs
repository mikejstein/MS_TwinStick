using UnityEngine;
using System.Collections;

/*
 * Abstract base class for an enemy.
*/
abstract public class Enemy : MonoBehaviour {

    public GameObject target;
    IEnemyMovement movement;
	// Use this for initialization
	void Start () {
        movement = GetComponent<IEnemyMovement>(); //get our movement component
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

}
