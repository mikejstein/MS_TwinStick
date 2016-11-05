using UnityEngine;
using System.Collections;

public enum GameScenes {
	menu,
	game
}
public class SceneManager : MonoBehaviour {
	private static SceneManager _instance;
	
	public static SceneManager Instance { get { return _instance; } }
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
	
	public void LoadScene(GameScenes scene) {
		if (scene == GameScenes.menu) {
			Application.LoadLevel("Menu");
		} else if (scene == GameScenes.game) {
			Application.LoadLevel("Main");
		}
	}
	                                    
}
