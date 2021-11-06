using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void ShowMenu()
    {
        this.transform.Find("GFX").gameObject.SetActive(true);
    }
    public void HideMenu()
    {
        this.transform.Find("GFX").gameObject.SetActive(false);
    }
}
