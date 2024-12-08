using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillarActive : MonoBehaviour
{
    public ParticleSystem iceSystem;
    public GameObject iceCrystalGroup;
    private AudioSource asIcePillar;
    public AudioClip placeCrystals;

    // Start is called before the first frame update
    void Start()
    {
        iceSystem = GetComponentInChildren<ParticleSystem>();
        asIcePillar = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (GameManager.Instance.gameOver == true)
        {
            iceSystem.Stop();
        }

        if (GameManager.Instance.deactivateIcePillar == true)
        {
            iceCrystalGroup.SetActive(false);
            iceSystem.Stop();
            GameManager.Instance.deactivateIcePillar = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.collectedAllEarth == true)
        {
            iceSystem.Play();
            GameManager.Instance.icePillarActive = true;
            iceCrystalGroup.SetActive(true);
            asIcePillar.PlayOneShot(placeCrystals, 1.0f);
        }
    }
}
