using UnityEngine;
using System.Collections;

public class EnemyTrapResponder : MonoBehaviour, TrapResponder{
	EnemyMovement em;
	float trapTime = 3;

	public void ExecuteTrap() {
		//Get the enemy move component
		em = gameObject.GetComponent("EnemyMovement") as EnemyMovement;
		em.ChangeSpeed(em.moveSpeed / 2);
		StartCoroutine(EndTrap(em));
	}

	IEnumerator EndTrap(EnemyMovement em) {
		yield return new WaitForSeconds(trapTime);
		em.ChangeSpeed(em.moveSpeed);
	}

}
