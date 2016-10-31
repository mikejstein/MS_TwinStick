using UnityEngine;
using System.Collections;

public delegate void MovedInRange(Vector3 target);
public delegate void MovedOutRange();

public interface IEnemyMovement  {

    void SetTarget(Vector3 newTarget); //every enemy movement must be able to set it's target
    event MovedInRange inRange; //has an event that reports when it is range of target
    event MovedOutRange outRange; //reports when it's out of range of target
}
