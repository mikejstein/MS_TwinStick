using UnityEngine;
using System.Collections;
using System;

public interface IEnemyMovement  {
	Action<GameObject> InRange {get; set;}
	Action OutRange {get; set;}
	void SetPlayer(GameObject p);
    void ChangeSpeed(float newSpeed); //Allows the controller to change it's movement speed
}

