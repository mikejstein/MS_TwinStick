using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public void OnTriggerEnter(Collider collider) {
		PowerUpResponder power = collider.GetComponent<PowerUpResponder>();
		if (power != null) {
			power.ExecutePowerUp();
		} else {
			power = collider.GetComponentInParent<PowerUpResponder>();
			if (power != null) {
				power.ExecutePowerUp();
			}
		}
	}
}
