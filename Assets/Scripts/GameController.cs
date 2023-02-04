using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameOverUi;

    void Start()
    {
        
    }

    void Update()
    {
        Attackable playerHealth = player.GetComponent<Attackable>();
        if (playerHealth.health < 0)
        {
            // display game over and restart scene
            return;
        }
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
