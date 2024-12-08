using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private PlayerController playerController;

    // UI
    // public TextMeshProUGUI healthText;
    public TextMeshProUGUI birdText;
    public TextMeshProUGUI fireCrystalText;
    public TextMeshProUGUI iceCrystalText;

    // Bird Collector
    public int collectibleBird = 0;
    public bool collectedAll = false;
    public bool nestFilled = false;

    // If contact with tornado, reset Birds
    public bool needToSpawnBirds = false;
    public bool deleteBirds = false;

    // Gem Collectors
    public int fireCore = 0;
    public bool collectedAllFire = false;
    public bool firePillarActive = false;
    public int iceCore = 0;
    public bool collectedAllEarth = false;
    public bool icePillarActive = false;
    public bool deactivateFirePillar = false;
    public bool deactivateIcePillar = false;

    // Meet the Elders
    public bool canShootFire = false;
    public bool canShootIce = false;
    public GameObject spellCastingIcons;

    // If Player dies Respawning Elementals
    public bool deleteElementals = false;
    public bool needtoSpawnElementals = false;
    public bool playerDead = false;

    // Meet the Gamayun
    public bool gameOver = false;
    public GameObject gameOverPopUp;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    void Update()
    {
        // Update Bird Counter
        if (collectibleBird >= 5)
        {
            collectedAll = true;
        }
        else
        {
            collectedAll = false;
        }
        birdText.text = collectibleBird + "/5";

        if(canShootFire == true && canShootIce == true)
        {
            spellCastingIcons.SetActive(true);
        }

        // Update Fire Gem Counter
        if (fireCore >= 4)
        {
            collectedAllFire = true;
        }
        else
        {
            collectedAllFire = false;
        }
        fireCrystalText.text = fireCore + "/4";

        // Update Earth Gem Counter
        if (iceCore >= 4)
        {
            collectedAllEarth = true;
        }
        else
        {
            collectedAllEarth = false;
        }
        iceCrystalText.text = iceCore + "/4";

        if (deleteBirds == true)
        {
            DestroyBirds();
            deleteBirds = false;
        }
        if(deleteElementals == true)
        {
            DestroyElementals();
            DestroyElementalCrystals();
            deleteElementals = false;
        }

        if (gameOver == true)
        {
            gameOverPopUp.SetActive(true);
        }
    }

    private void DestroyBirds()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("BabyBird");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
        collectibleBird = 0;
        deleteBirds = false;
        needToSpawnBirds = true;
    }
    private void DestroyElementals()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Elemental");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
        needtoSpawnElementals = true;
    }
    private void DestroyElementalCrystals()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ElementalCrystal");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
        fireCore = 0;
        iceCore = 0;
    }
}
