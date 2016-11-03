using UnityEngine;
using System.Collections;

/*
 * "Forward" for the player means whatever direction I've got my nose pointed in.
 */ 
public class PlayerBody : MonoBehaviour, IPlayerBody {

	public Vector3 GetForward()
    {
        return transform.forward;
    }

    public void SetRotation(Quaternion newRotation)
    {
        transform.rotation = newRotation;
    }
}
