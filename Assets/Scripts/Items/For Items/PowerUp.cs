using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public void OnTriggerEnter(Collider collider) {
		PowerUpResponder power = collider.GetComponent<PowerUpResponder>();
		if (power != null) {
            Execute(power);
		} else {
			power = collider.GetComponentInParent<PowerUpResponder>();
			if (power != null) {
                Execute(power);
            }
		}
	}

    private void Execute(PowerUpResponder pr)
    {
        pr.ExecutePowerUp();
        Destroy(gameObject); // Kill the power up
        ItemManager.Instance.RespawnPowerUp(); // Tell the item manager to spawn a new power up
        
    }
}
