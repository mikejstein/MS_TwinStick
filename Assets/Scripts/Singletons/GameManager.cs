using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	private static GameManager _instance;
	
	public static GameManager Instance { get { return _instance; } }
	private int _score;
	private int score {
		get { return _score; }
		set {
			scoreDisplay.text = value.ToString();

			_score = value;
		}
	}
	public Text scoreDisplay;
	public GameObject gameOverPanel;
	
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

	public void resetGame() {
		Debug.Log ("RESET THIS FUCKER");

		//Delete all our obects

		//Spawn a player at 0,0

		//Set our score to 0
		score = 0;
		//Reset our spawn stuff
		//
	}

}
