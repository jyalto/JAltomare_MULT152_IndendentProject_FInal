using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeetIceElder : MonoBehaviour
{
    private GameObject iceElder;
    private Animator iceAnim;
    public GameObject popUp;
    // Start is called before the first frame update
    void Start()
    {
        iceElder = GameObject.Find("IceElder");
        iceAnim = iceElder.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.canShootIce = true;
            iceAnim.SetTrigger("playerMet");
            popUp.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }

}
