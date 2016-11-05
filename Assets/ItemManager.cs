using UnityEngine;
using System.Collections;

/*
 * Class for spawning traps and power ups.
 * We can spawn them anywhere in the game area, BUT there can only be one trap and one powerup on the board at a time
 */
public class ItemManager : MonoBehaviour {
    private static ItemManager _instance;
    public static ItemManager Instance { get { return _instance; } }


    public MonoBehaviour trapPrefab;
    public MonoBehaviour powerupPrefab;


    public GameObject spawnArea; //holds our floor
    private float spawnRange; //How far the floor goes
    public float playerSpawnRange; //how close to the player will items spawn
    public float respawnTime; //how long for someting to respawn

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

    // Use this for initialization
    private void Start()
    {

        // Our spawn radius is the x scale of our area. 

        spawnRange = ((spawnArea.transform.lossyScale.x) / 2) - 5f;
    }

    /*
     * Pick a random point on our spawn area to place an item.
     * Unlike enemies, we WANT items to show up near the player.
	 * It's going to be pretty barren without them.
	 */
    private Vector3 GenerateSpawnPoint()
    {
        //Pick point somewhere int the radius of our player
        Vector3 newPoint = new Vector3(Random.Range(-playerSpawnRange, playerSpawnRange), 1, Random.Range(-playerSpawnRange, playerSpawnRange));

        //Make sure the point is on our floor. We don't want to put items out in space.
        bool inX = (newPoint.x > -spawnRange) && (newPoint.x < spawnRange);
        bool inZ = (newPoint.z > -spawnRange) && (newPoint.z < spawnRange);

        if (inX && inZ)
        {
            return newPoint;
        }
        else
        {
            return GenerateSpawnPoint();
        }
    }

    IEnumerator Respawn(MonoBehaviour obj)
    {
        yield return new WaitForSeconds(respawnTime);
        MonoBehaviour spawn = Instantiate(obj); //instantiate the random enemy
        spawn.transform.position = GenerateSpawnPoint();

    }
    public void RespawnTrap()
    {
        StartCoroutine(Respawn(trapPrefab));
    }

    public void RespawnPowerUp()
    {
        StartCoroutine(Respawn(powerupPrefab));        
    }
}
