using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverPanel;
    public Slider healthDisplay;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if(player != null)
        {
            Attackable playerHealth = player.GetComponent<Attackable>();
            if (playerHealth.health < 0)
            {
                // display game over and restart scene
                return;
            }

            SetHealthBar(playerHealth.HealthPercentage());

            PlayerController playerController = player.GetComponent<PlayerController>();
            if (!playerController.IsAlive())
            {
                gameOverPanel.SetActive(true);
            }
        }
    }

    public void SetHealthBar(float healthVal)
    {
        healthDisplay.value = healthVal;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
