using UnityEngine;
using System.Collections;

public class ProjectilePowerUpResponder : MonoBehaviour, PowerUpResponder {
	float powerTime = 3;
	GameObject pObject;


	public void ExecutePowerUp() {
		Projectile projectile = gameObject.GetComponent<IProjectile>() as Projectile;
		pObject = projectile.gameObject;
		pObject.transform.localScale = new Vector3(10f,10f,10f);
		StartCoroutine(EndPower());

	}

	IEnumerator EndPower() {
		yield return new WaitForSeconds(powerTime);
		pObject.transform.localScale = new Vector3(1f,1f,1f);
	}

}
