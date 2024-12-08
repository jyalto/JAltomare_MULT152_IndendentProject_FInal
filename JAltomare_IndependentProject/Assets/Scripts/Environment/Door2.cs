using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    private Animator door2Anim;

    // Start is called before the first frame update
    void Start()
    {
        door2Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.canShootFire == true && GameManager.Instance.canShootIce == true)
        {
            door2Anim.Play("Door2Down");
        }
    }
}
