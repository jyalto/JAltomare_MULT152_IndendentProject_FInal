using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float OnscreenDelay = 2f;
    // Start is called before the first frame update

    void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elemental"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
