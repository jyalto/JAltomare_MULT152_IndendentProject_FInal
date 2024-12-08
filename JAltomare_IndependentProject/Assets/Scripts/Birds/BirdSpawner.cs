using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab; // Reference to the baby bird prefab
    public int numberOfBirds = 5; // Number of birds to spawn

    public Vector3[] positionArray1 = new[] { new Vector3(400.3f, 13.81f, 254.7f), new Vector3(445.7f, 13.1f, 268.4f), new Vector3(411.6f, 13.1f, 276.8f), new Vector3(385.6f, 13.1f, 268.8f), new Vector3(381.5f, 13.1f, 297.3f)};
    public Vector3[] positionArray2 = new[] { new Vector3(400.3f, 13.81f, 254.7f), new Vector3(448.25f, 13.1f, 278.4f), new Vector3(411.6f, 13.1f, 276.8f), new Vector3(364.5f, 13.1f, 264.9f), new Vector3(392.4f, 13.1f, 309.2f) };
    public Vector3[] positionArray3 = new[] { new Vector3(400.3f, 13.81f, 254.7f), new Vector3(423f, 16f, 256.8f), new Vector3(410.3f, 13.1f, 285.4f), new Vector3(366.3f, 17.1f, 283.6f), new Vector3(411.4f, 13.1f, 310.2f) };

    public GameManager gameManager;

    void Start()
    {
        SpawnBirds();
    }
    void Update()
    {
        if (gameManager.needToSpawnBirds == true)
        {
            SpawnBirds();
            gameManager.needToSpawnBirds = false;
        }
    }
    void SpawnBirds()
    {
        // choose which array of locations to spawn
        int randNum = Random.Range(0, 3);

        if (randNum == 0) 
        {
            for (int i = 0; i < positionArray1.Length; i++)
            {
                Vector3 birdPosition = positionArray1[i];
                Instantiate(birdPrefab, birdPosition, birdPrefab.transform.rotation);
            }
        }
        else if (randNum == 1) 
        {
            for (int i = 0; i < positionArray2.Length; i++)
            {
                Vector3 birdPosition = positionArray2[i];
                Instantiate(birdPrefab, birdPosition, birdPrefab.transform.rotation);
            }
        }
        else
        {
            for (int i = 0; i < positionArray3.Length; i++)
            {
                Vector3 birdPosition = positionArray2[i];
                Instantiate(birdPrefab, birdPosition, birdPrefab.transform.rotation);
            }
        }
    }
}
