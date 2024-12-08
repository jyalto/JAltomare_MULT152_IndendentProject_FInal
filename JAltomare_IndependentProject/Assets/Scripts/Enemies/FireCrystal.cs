using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrystal : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.fireCore++;
            AudioManager.instance.PlaySFX("FireCrystalPickUp");

        }
    }
}
