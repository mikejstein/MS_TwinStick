using UnityEngine;
using System.Collections;

public interface IWeapon {
    void SetTarget(Vector3 newTarget);
    void fire();
}
