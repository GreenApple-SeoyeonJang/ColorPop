using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour {

    public GameObject Quit;

    void Start()
    {
        Quit.SetActive(false);
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                Quit.SetActive(true);
            }
        }
    }

    public void NormalRestart()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("NormalLoadingScene");
    }

    public void CrazyRestart()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("CrazyLoadingScene");
    }

    public void GoMenu()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("StartMenu");
    }
}
