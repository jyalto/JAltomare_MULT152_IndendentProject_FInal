using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nest : MonoBehaviour
{ 
    public GameManager gameManager;
    public GameObject birdGroup;

    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.collectedAll == true)
        {
        Instantiate(birdGroup, birdGroup.transform.position, birdGroup.transform.rotation);
        gameManager.nestFilled = true;
        }
    }
}   
