using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    [SerializeField] private GameObject menu;

    public void SpawnBall()
    {
        Instantiate(ball);
    }

    public void Start()
    {
        menu?.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            menu.SetActive(!menu.activeSelf);
            if (menu.activeSelf)
                PauseGame();
            else
                ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
