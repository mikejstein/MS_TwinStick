using UnityEngine;
using System.Collections;

public class PlayerTrapResponder : MonoBehaviour, TrapResponder {

	PlayerControl pc;
	public float trapTime = 3;
	
	public void ExecuteTrap() {
		//Get the enemy move component
		pc = gameObject.GetComponent("PlayerControl") as PlayerControl;
		pc.moveSpeed = pc.moveSpeed / 2;
		StartCoroutine(EndTrap());
	}
	
	IEnumerator EndTrap() {
		yield return new WaitForSeconds(trapTime);
		pc.moveSpeed = pc.moveSpeed * 2;
	}
}
