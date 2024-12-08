using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePillarActive : MonoBehaviour
{
    public GameManager gameManager;
    public ParticleSystem fireSystem;
    public GameObject fireCrystalGroup;
    private AudioSource asFirePillar;
    public AudioClip placeCrystals;

    // Start is called before the first frame update
    void Start()
    {

        fireSystem = GetComponentInChildren<ParticleSystem>();
        asFirePillar = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (gameManager.gameOver == true)
        {
            fireSystem.Stop();
        }
        if (GameManager.Instance.deactivateFirePillar == true)
        {
            fireCrystalGroup.SetActive(false);
            fireSystem.Stop();
            GameManager.Instance.deactivateFirePillar = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.collectedAllFire == true)
        {
            fireSystem.Play();
            gameManager.firePillarActive = true;
            fireCrystalGroup.SetActive(true);
            asFirePillar.PlayOneShot(placeCrystals, 1.0f);
        }

    }
}
