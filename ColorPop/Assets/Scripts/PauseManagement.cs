using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManagement : MonoBehaviour {

    public GameObject PausePanel;

    void Start () {
        PausePanel.SetActive(false);
    }
	
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 0;
                PausePanel.SetActive(true);
            }
        }
    }
}
