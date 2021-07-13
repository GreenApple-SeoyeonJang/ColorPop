using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {

    public GameObject PausePanel;

    public void Resume()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoMenu()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }
}
