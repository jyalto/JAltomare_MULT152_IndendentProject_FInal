using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDeathScreen : MonoBehaviour
{
    PlayerController playerController;
    public GameObject deathScreen;
    private void Start()
    {
        playerController = GameObject.Find("PLAYER").GetComponent<PlayerController>();
    }
    public void RespawnButton()
    {
        playerController.Respawn();

    }
    public void MainMenuFromDeath()
    {
        SceneManager.LoadScene(1);
    }
}
