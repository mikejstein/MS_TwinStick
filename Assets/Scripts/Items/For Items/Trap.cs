using UnityEngine;
using System.Collections;

/*
 * Class that excutes trap behavior
 */
public class Trap : MonoBehaviour {
	
	public void OnTriggerEnter(Collider collider) {
		//Check to see if the base object has a collider
		TrapResponder tr = collider.GetComponent<TrapResponder>();
		if (tr != null) {
			tr.ExecuteTrap();
		} else {
			// If the base didn't have one, check it's parent.
			// This is to account for the different way player and enemy are organized
			// I figured there are goign to be more enemies than players on the board, so put the check for enemies first.
			tr = collider.GetComponentInParent<TrapResponder>();
			if (tr != null) {
				tr.ExecuteTrap();
			}
		}
	}
}
