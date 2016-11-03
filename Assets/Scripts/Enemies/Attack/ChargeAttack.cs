using UnityEngine;
using System.Collections;

public class ChargeAttack : MonoBehaviour, IAttack {
	
	public float attackSpeed = 20f;
	private EnemyMovement move;
	
	void Start()
	{
		move = GetComponent<EnemyMovement>();
	}
	
	
	/*
     * Stop the attack, which means we need to set our movement speed back to normal
     */
	public void StopAttack()
	{
		move.ChangeSpeed(move.moveSpeed);
	}
	
	/*
     * Start the attack - set move speed to our attack speed
     */
	public void StartAttack(Vector3 target)
	{
		move.ChangeSpeed(attackSpeed);
	}
	
	/*
     * Register that we've hit the player
     */
	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("HIT PLAYER");
		}
	}
}
