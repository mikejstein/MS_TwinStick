using UnityEngine;
using System.Collections;

public delegate void MovedInRange(Vector3 target);
public delegate void MovedOutRange();

public interface IEnemyMovement  {

    void SetTarget(Vector3 newTarget); //every enemy movement must be able to set it's target
    void SetPlayerLocation(Vector3 newPlayerLocation); //set my player's location
    void ChangeSpeed(float newSpeed); //Allows the controller to change it's movement speed
    event MovedInRange inRange; //has an event that reports when it is range of target
    event MovedOutRange outRange; //reports when it's out of range of target
}
