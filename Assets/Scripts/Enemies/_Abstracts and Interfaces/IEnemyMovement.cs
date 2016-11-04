using UnityEngine;
using System.Collections;

public delegate void MovedInRangeOfLocation(Vector3 target); //i'm in range of a location I want to attack
public delegate void MovedInRageOfObject(GameObject target); //I'm in range of an object I want to attack
public delegate void MovedOutRange();

public interface IEnemyMovement  {

    void SetTarget(Vector3 newTarget); //every enemy movement must be able to set it's target
    void SetPlayerLocation(Vector3 newPlayerLocation); //set my player's location
    void ChangeSpeed(float newSpeed); //Allows the controller to change it's movement speed
    event MovedInRangeOfLocation inRangeLocation; //has an event that reports when it is range of target
	event MovedInRageOfObject inRangeObject;
    event MovedOutRange outRange; //reports when it's out of range of target
}

