using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }    
    }
}
