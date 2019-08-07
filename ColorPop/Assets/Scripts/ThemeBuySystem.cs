using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeBuySystem : MonoBehaviour {

    public GameObject NotEnoughCoinPanel;

    public void neonTheme()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("ThemePick", 0);
    }

    public void pasteTheme()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("ThemePick", 1);
    }

    public void neonNotActive()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("ThemePick", 0);
    }
    public void pastelCannotBuy()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        if(PlayerPrefs.GetInt("Coin",0) >= 1000)
        {
            PlayerPrefs.SetInt("PastelActive", 1);
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) - 1000);
            PlayerPrefs.SetInt("ThemePick", 1);
        }
        else
        {
            NotEnoughCoinPanel.SetActive(true);
            PlayerPrefs.SetInt("ThemePick", 0);
        }
    }
    public void pastelNotActive()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("ThemePick", 1);
    }
    public void okButton()
    {
        NotEnoughCoinPanel.SetActive(false);
    }
}
