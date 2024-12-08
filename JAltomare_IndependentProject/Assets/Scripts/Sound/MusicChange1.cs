using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlayMusic("BirdCollecting");
        }

    }
}
