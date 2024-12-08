using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBirds : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.collectibleBird = 0;
            gameManager.deleteBirds = true;

        }
    }
}
