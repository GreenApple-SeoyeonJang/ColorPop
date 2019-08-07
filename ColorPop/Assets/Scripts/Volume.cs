using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    public Slider backVolume;

    private float backVol = 1f;

	// Use this for initialization
	void Start () {
        backVol = PlayerPrefs.GetFloat("backvol", 1f);
        backVolume.value = backVol;
        GameObject.Find("StartProgram").GetComponent<AudioSource>().volume = backVolume.value;
    }
	
	// Update is called once per frame
	void Update () {
        SoundSlider();
	}

    public void SoundSlider()
    {
        GameObject.Find("StartProgram").GetComponent<AudioSource>().volume = backVolume.value + 0.2f;
        backVol = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }

}
