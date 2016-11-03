using UnityEngine;
using System.Collections;

public interface IProjectile {
	void FireAtTarget(GameObject newTarget);
	void FireAtTarget(Vector3 newTarget);
}
