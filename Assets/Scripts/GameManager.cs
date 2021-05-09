using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    void Update ()
    {
        if (player.transform.position.y < -4f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void WinLevel()
    {
        SceneManager.LoadScene(0);
    }
}