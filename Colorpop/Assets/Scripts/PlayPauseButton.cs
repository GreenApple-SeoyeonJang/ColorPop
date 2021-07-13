using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPauseButton : MonoBehaviour {
    public GameObject PausePanel;

    public void PlayPause()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
}
