using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    private void ResetMenu()
    {
        this.transform.Find("GFX/WinImg").gameObject.SetActive(false);
        this.transform.Find("GFX/LoseImg").gameObject.SetActive(false);
        this.transform.Find("GFX/Title").gameObject.SetActive(true);
    }
    public void ShowMenu()
    {
        Time.timeScale = 0; // there is the main game menu that does the same thing, but whatever, it's just quicker to copy here
        this.ResetMenu();
        this.transform.Find("GFX").gameObject.SetActive(true);
    }
    public void HideMenu()
    {
        Time.timeScale = 1;
        this.transform.Find("GFX").gameObject.SetActive(false);
    }
    public void GameEnd(bool didWin)
    {
        this.transform.Find("GFX/Title").gameObject.SetActive(false);
        this.transform.Find("GFX/WinImg").gameObject.SetActive(didWin);
        this.transform.Find("GFX/LoseImg").gameObject.SetActive(!didWin);
        ShowMenu();
    }
}
