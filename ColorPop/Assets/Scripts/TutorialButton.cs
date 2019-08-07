using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour {

    public GameObject TutorialPanel;
    public GameObject Title;

    public void closeTutorialPanel()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        TutorialPanel.SetActive(false);
        Title.SetActive(true);
    }
}
