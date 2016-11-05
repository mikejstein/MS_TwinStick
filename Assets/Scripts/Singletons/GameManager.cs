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
    public GameObject startPanel;
	
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		} else {
			_instance = this;
		}
        Time.timeScale = 0;
    }

	
	public static void IncrementScore() {
		Instance.score += 100;
	}

	public static void DecrementScore() {
		Instance.score -= 100;
        
        if (Instance.score <= 0)
        {
            Instance.EndGame();
        }
	}
    
    private void EndGame()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void Startgame()
    {
        startPanel.SetActive(false);
        Destroy(startPanel);
        Time.timeScale = 1;
    }
	public void resetGame() {

        //Delete all our enemies, items, and projectiles
        Enemy[] enemies = FindObjectsOfType(typeof(Enemy)) as Enemy[];
        foreach (Enemy e in enemies)
        {
            Destroy(e.gameObject);

        }

        Projectile[] projectiles = FindObjectsOfType(typeof(Projectile)) as Projectile[];
        foreach (Projectile p in projectiles)
        {
            Destroy(p.gameObject);

        }

        Trap[] traps = FindObjectsOfType(typeof(Trap)) as Trap[];
        foreach (Trap t in traps)
        {
            Destroy(t.gameObject);

        }

        PowerUp[] powers = FindObjectsOfType(typeof(PowerUp)) as PowerUp[];
        foreach (PowerUp p in powers)
        {
            Destroy(p.gameObject);

        }


        //Set our score to 0
        score = 0;

        //Reset our spawn stuff
        ItemManager.Instance.RespawnPowerUp();
        ItemManager.Instance.RespawnTrap();

        //Resume time
        Time.timeScale = 1f;

        //Hide the game over hud
        gameOverPanel.SetActive(false);

	}

}
