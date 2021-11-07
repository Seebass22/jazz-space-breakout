using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    private GameObject winRef;
    private GameObject loseRef;
    private GameObject titleRef;
    private GameObject allRef;
    private void Awake()
    {
        winRef = this.transform.Find("GFX/WinImg").gameObject;
        loseRef = this.transform.Find("GFX/LoseImg").gameObject;
        titleRef = this.transform.Find("GFX/Title").gameObject;
        allRef = this.transform.Find("GFX").gameObject;
    }
    private void ResetMenu()
    {
        winRef.SetActive(false);
        loseRef.SetActive(false);
        titleRef.SetActive(true);
    }
    public void ShowMenu()
    {
        Time.timeScale = 0; // there is the main game menu that does the same thing, but whatever, it's just quicker to copy here
        this.ResetMenu();
        allRef.SetActive(true);
    }
    public void HideMenu()
    {
        Time.timeScale = 1;
        allRef.gameObject.SetActive(false);
    }
    public void GameEnd(bool didWin)
    {
        ShowMenu();
        titleRef.SetActive(false);
        winRef.SetActive(didWin);
        loseRef.SetActive(!didWin);
    }
}
