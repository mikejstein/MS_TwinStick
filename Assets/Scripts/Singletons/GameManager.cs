using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private static GameManager _instance;
	
	public static GameManager Instance { get { return _instance; } }
	private int score = 0;
	
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
	}

	
	public static void IncrementScore() {
		Instance.score += 100;
	}

	public static void DecrementScore() {
		Instance.score -= 100;
	}

}
