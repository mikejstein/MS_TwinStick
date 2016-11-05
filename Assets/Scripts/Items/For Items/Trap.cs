using UnityEngine;
using System.Collections;

/*
 * Class that excutes trap behavior
 */
public class Trap : MonoBehaviour {
    public AudioSource audio;

	public void OnTriggerEnter(Collider collider) {
		//Check to see if the base object has a collider
		TrapResponder tr = collider.GetComponent<TrapResponder>();
		if (tr != null) {
            Execute(tr);
		} else {
			// If the base didn't have one, check it's parent.
			// This is to account for the different way player and enemy are organized
			// I figured there are going to be more enemies than players on the board, so put the check for enemies first.
			tr = collider.GetComponentInParent<TrapResponder>();
			if (tr != null) {
                Execute(tr);
			}
		}
	}

    private void Execute(TrapResponder tr)
    {
        audio.Play();
        Destroy(gameObject); //kill the trap
        ItemManager.Instance.RespawnTrap();
        tr.ExecuteTrap();

    }
}
