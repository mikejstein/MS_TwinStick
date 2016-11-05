using UnityEngine;
using System.Collections;

/*
 * Class responsible for spawning enemies
 */
public class EnemyManager : MonoBehaviour {
	private static EnemyManager _instance;
	
	public static EnemyManager Instance { get { return _instance; } }
    public float enemiesInWave = 5;


	private float timeSinceLastSpawn; //how long since we last spawned an enemy
	private int spawnSinceDecrement = 0; //how many enemies have we spawned since we last changed our spawn rate
	public float minimumSpawnBreak; //Time between spawns - our spawn rate
	public float spawnBreakFloor; //the fastest enemies will ever spawn
	public int enemiesPerSpawnRate; //Enemies spawned between changing our spawn rate


    private float defaultSpawnBreak;
    

    //I want to spawn an enemy every 3 seconds.
    //Eventually, 

	public MonoBehaviour[] prefabs; //Holds our enemy prefabs

	private Camera myCamera; //holds our camera
	public GameObject spawnArea; //holds our floor

	private float spawnRange;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        myCamera = FindObjectOfType<Camera>();

        defaultSpawnBreak = minimumSpawnBreak;
        // Our spawn radius is the x scale of our area. 
        // This only works if the area is either a cirlce or square - something with equal scale in both X and Z axis
        spawnRange = ((spawnArea.transform.lossyScale.x) / 2) - 5f;
    }


    private void FixedUpdate() {
		timeSinceLastSpawn += Time.deltaTime; // Increment our time since we last spawned
		if (timeSinceLastSpawn >= minimumSpawnBreak) { //If our minimum spawn break is greater than the time since we last spawned
			SpawnEnemy(); //spawn an enemy
			spawnSinceDecrement++; //increase our 'how many enemies since last changed our spawn rate' counter
			if (spawnSinceDecrement >= enemiesPerSpawnRate) {
				float spawnDecrementer = Random.Range(0.2f, 0.7f); //reduce our spawn rate by an amount between 0.5 and 2.0 seconds
				minimumSpawnBreak -= spawnDecrementer;
				if (minimumSpawnBreak < spawnBreakFloor) {
					minimumSpawnBreak = spawnBreakFloor;
				}

				spawnSinceDecrement = 0; //reset our spawn since decrement counters
			}
			timeSinceLastSpawn = 0;
		}
	}

	/*
	 * Pick a random point on our spawn area to place a new enemey.
	 */
	private Vector3 GenerateSpawnPoint() {
		//Pick point somewhere int the radius of our circle.
		Vector3 newPoint = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
		//We don't want enemies spawning on screen, so make sure they spawn outside the camera view
		//Convert our point from world space to camera space


		Vector3 cameraPoint = myCamera.WorldToViewportPoint(newPoint);

		bool xOutView = ((cameraPoint.x < 0) || (cameraPoint.x > 1));
		bool yOutView = ((cameraPoint.y < 0) || (cameraPoint.y > 1));
		bool zOutView = (cameraPoint.z < 0);
		
		if (xOutView || yOutView  || zOutView) {

			return newPoint;
		} else {
			return GenerateSpawnPoint();
		}
	}

	private void SpawnEnemy() {
        for (int i = 0; i < enemiesInWave; i++)
        {
            MonoBehaviour prefab = prefabs[Random.Range(0, prefabs.Length)]; //pick a random enemy to spawn
            MonoBehaviour spawn = Instantiate(prefab); //instantiate the random enemy
            spawn.transform.position = GenerateSpawnPoint();
        }
	}
	


    public void ResetSpawn()
    {
        minimumSpawnBreak = defaultSpawnBreak;
        timeSinceLastSpawn = 0;
        spawnSinceDecrement = 0;
    }



}
