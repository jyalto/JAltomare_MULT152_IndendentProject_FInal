using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviroParticles : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem windSystem;
    public GameManager gameManager;
    void Start()
    {
        windSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.nestFilled == true)
        {
            windSystem.Stop();
        }
    }
}
