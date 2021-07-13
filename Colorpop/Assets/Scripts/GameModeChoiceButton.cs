using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeChoiceButton : MonoBehaviour {

    private void Start()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("bgm").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
    }
    public void Normal()
    {
    GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
    SceneManager.LoadScene("NormalLoadingScene");
    }

    public void Crazy()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("CrazyLoadingScene");
    }

    public void ModeToMain()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("StartMenu");
    }
}
