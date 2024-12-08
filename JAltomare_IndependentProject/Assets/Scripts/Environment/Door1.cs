using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
    private Animator door1Anim;

    // Start is called before the first frame update
    void Start()
    {
        door1Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.nestFilled == true)
        {
            door1Anim.Play("DoorDrop");
        }
    }
}
