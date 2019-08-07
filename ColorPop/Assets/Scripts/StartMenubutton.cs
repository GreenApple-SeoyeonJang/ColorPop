using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenubutton : MonoBehaviour {
    public GameObject OptionPanel;
    public GameObject ScorePanel;
    public GameObject Title;
    public GameObject Buttons;
    public GameObject NotEnoughCoinPanel;

    public void OpenStart()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("GameModeChoice");
    }

    public void openOption()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Title.SetActive(false);
        Buttons.SetActive(false);
        NotEnoughCoinPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void openScore()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Title.SetActive(false);
        Buttons.SetActive(false);
        ScorePanel.SetActive(true);
    }

    
}
