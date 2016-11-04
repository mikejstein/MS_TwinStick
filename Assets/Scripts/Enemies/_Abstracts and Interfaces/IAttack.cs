using UnityEngine;
using System.Collections;

public interface IAttack
{
    void StartAttack(Vector3 target);
	void StartAttack(GameObject target); 
    void StopAttack();
}
