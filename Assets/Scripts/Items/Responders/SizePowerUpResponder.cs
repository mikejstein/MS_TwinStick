using UnityEngine;
using System.Collections;

public class SizePowerUpResponder : MonoBehaviour, PowerUpResponder {
    public float powerTime;

    public void ExecutePowerUp()
    {
        Vector3 lastScale = transform.localScale;
        transform.localScale = lastScale * 2;
        StartCoroutine(EndPower(lastScale));
    }

    IEnumerator EndPower(Vector3 lastScale)
    {
        yield return new WaitForSeconds(powerTime);
        transform.localScale = lastScale;
    }
}
