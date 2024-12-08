using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject popUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            popUp.SetActive(true);
            GameManager.Instance.gameOver = true;
            AudioManager.instance.PlayMusic("MeetElementals");
        }
    }
    public void OnContinueButton()
    {
        SceneManager.LoadScene(1);
    }
}
