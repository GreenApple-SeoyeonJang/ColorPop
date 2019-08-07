using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour {

    public GameObject OptionPanel;
    public GameObject Title;
    public GameObject Buttons;
    public GameObject NotEnoughCoinPanel;

    public void closeOptionPanel()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        OptionPanel.SetActive(false);
        Title.SetActive(true);
        Buttons.SetActive(true);
        NotEnoughCoinPanel.SetActive(false);
    }
}
