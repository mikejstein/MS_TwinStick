using UnityEngine;
using System.Collections;

public interface IPlayerBody {
    Vector3 GetForward();
    void SetRotation(Quaternion newRotation);
}
