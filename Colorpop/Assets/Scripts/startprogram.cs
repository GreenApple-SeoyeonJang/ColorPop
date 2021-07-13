using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startprogram : MonoBehaviour {

    public GameObject quit;
    public GameObject optionPanel;
    public GameObject ScorePanel;

    void Start()
    {
        Time.timeScale = 1;
        quit.SetActive(false);
        optionPanel.SetActive(false);
        ScorePanel.SetActive(false);
    }

    void Update () {
        
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                quit.SetActive(true);
            }
        }
    }
}
