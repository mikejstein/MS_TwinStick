using UnityEngine;
using System.Collections;

public class Boom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * 200);
    }
	
}
