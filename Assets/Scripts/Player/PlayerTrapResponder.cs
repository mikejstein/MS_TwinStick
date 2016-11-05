using UnityEngine;
using System.Collections;

public class PlayerTrapResponder : MonoBehaviour, TrapResponder {

	PlayerControl pc; 
    PlayerSound sound;

	public float trapTime = 3;
	
    public void Start()
    {
        pc = gameObject.GetComponent("PlayerControl") as PlayerControl; // cache a reference to our move controller
        sound = GetComponent("PlayerSound") as PlayerSound; //cache a reference to my sound component

    }
    public void ExecuteTrap() {
        //Get the player move controller
        sound.PlayBadItemSound();
		pc.moveSpeed = pc.moveSpeed / 2;
		StartCoroutine(EndTrap());
	}
	
	IEnumerator EndTrap() {
		yield return new WaitForSeconds(trapTime);
		pc.moveSpeed = pc.moveSpeed * 2;
	}
}
