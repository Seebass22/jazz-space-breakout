using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public CinemachineVirtualCamera ballFollowingCamera;
    [SerializeField] private GameObject menu;
    public bool canSpawnBall = true;

    private void Start()
    {
        this.ballFollowingCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void SpawnBall()
    {
        if (!canSpawnBall)
            return;
        
        canSpawnBall = false;
        GameObject newBall = Instantiate(ball);
        ballFollowingCamera.m_Follow = newBall.transform;
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

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
