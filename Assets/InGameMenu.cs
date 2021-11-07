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
        this.ResetMenu();
        this.transform.Find("GFX").gameObject.SetActive(true);
    }
    public void HideMenu()
    {
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
