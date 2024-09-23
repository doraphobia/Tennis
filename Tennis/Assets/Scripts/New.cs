using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ObjectSpawnerAtSpecificTimes : MonoBehaviour
{
    public string objectTagToDetect;     
    public GameObject objectToSpawn;    
    public Transform[] spawnLocations;    
    public KeyCode correctKey;           
    public KeyCode[] wrongKeys;          
    public string gameOverSceneName = "GameOver"; // Name of the Game Over

    public float[] spawnTimes;            //  times to spawn the objects 

    private int currentSpawnIndex = 0;    //  track the current spawn time
    private GameObject spawnedObject;     
    private bool objectDetected = false;  //  tag is gone

    void Start()
    {
        StartCoroutine(CheckForSpawnAtSpecificTimes());
    }

    void Update()
    {
        if (GameObject.FindWithTag(objectTagToDetect) == null && !objectDetected)
        {
            objectDetected = true;  
        }

        if (spawnedObject != null)
        {
            if (Input.GetKeyDown(correctKey))
            {
                Destroy(spawnedObject);
                Debug.Log("Correct destroyed.");
            }

            foreach (KeyCode wrongKey in wrongKeys)
            {
                if (Input.GetKeyDown(wrongKey))
                {
                    LoseGame();
                    break;  
                }
            }
        }
    }

    // Coroutine
    IEnumerator CheckForSpawnAtSpecificTimes()
    {
        while (true)
        {
            // Wait
            if (!objectDetected)
            {
                yield return null;  
            }

            if (currentSpawnIndex < spawnTimes.Length)
            {
                float nextSpawnTime = spawnTimes[currentSpawnIndex];
                yield return new WaitForSeconds(nextSpawnTime);  

             
                SpawnObjectAtRandomLocation();
                currentSpawnIndex++;  
            }
            else
            {
                yield break;  
            }
        }
    }

    void SpawnObjectAtRandomLocation()
    {
        if (objectToSpawn != null && spawnLocations.Length > 0)
        {
            // Destroy the old object before spawning a new 
            if (spawnedObject != null)
            {
                Destroy(spawnedObject);
            }

            // Choose a random spawn location 
            int randomIndex = Random.Range(0, spawnLocations.Length);
            Transform randomLocation = spawnLocations[randomIndex];

            spawnedObject = Instantiate(objectToSpawn, randomLocation.position, randomLocation.rotation);
        }
        else
        {
            Debug.LogError("!");
        }
    }

    void LoseGame()
    {
        Debug.Log("Wrong ! lost the game.");
        SceneManager.LoadScene(gameOverSceneName);  // Load the Game Over 
    }
}
