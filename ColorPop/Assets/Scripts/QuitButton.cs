using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    public GameObject Quit;

    public void QuitYes()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void QuitNo()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        Quit.SetActive(false);
    }
}
