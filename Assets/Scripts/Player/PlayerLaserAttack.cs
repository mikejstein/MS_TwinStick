using UnityEngine;
using System.Collections;

/*
 * Class that defines a laser attack for the player
 */
public class PlayerLaserAttack : MonoBehaviour, IPlayerAttack {
    public LineRenderer lineRenderer;
    // Use this for initialization
    void Start() {
    }


    public void Attack(Vector3 InDirection)
    {
        RaycastHit hit;
        Debug.DrawRay(gameObject.transform.position, InDirection);
        if (Physics.Raycast(gameObject.transform.position, InDirection, out hit))
        {
            DrawWeapon(hit);
            Debug.Log(hit);
        }
    }

    public void EndAttack()
    {
        if (lineRenderer.enabled) // hide the line rendered when the player is not attacking
        {
            lineRenderer.enabled = false;
        }
    }

    private void DrawWeapon(RaycastHit hit)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, gameObject.transform.position);
        lineRenderer.SetPosition(1, hit.point);
    }

}


