using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBirds : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (gameManager.deleteBirds == true)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("BabyBird");
            foreach (GameObject obj in objectsWithTag) 
            {
                Destroy(obj);
            }
            gameManager.deleteBirds = false;
            gameManager.needToSpawnBirds = true;
        }


    }
    private void OnTriggerEnter(Collider other)
    {

    }
}
