using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour
{
    private Animator door3Anim;

    // Start is called before the first frame update
    void Start()
    {
        door3Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.firePillarActive == true && GameManager.Instance.icePillarActive == true)
        {
            Invoke("LowerDoorThree", 5);
        }
    }

    void LowerDoorThree()
    {
        door3Anim.Play("Door3Down");
    }
}
