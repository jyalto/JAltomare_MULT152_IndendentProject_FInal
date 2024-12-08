using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBirds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        if (GameManager.Instance.deleteBirds == true)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("BabyBird");
            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
            GameManager.Instance.deleteBirds = false;
            GameManager.Instance.needToSpawnBirds = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.collectibleBird++;
        }
    }
}
