using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreButton : MonoBehaviour {

    public GameObject ScorePanel;
    public GameObject Title;
    public GameObject Buttons;

    public void closeScore()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        ScorePanel.SetActive(false);
        Title.SetActive(true);
        Buttons.SetActive(true);
    }

}
