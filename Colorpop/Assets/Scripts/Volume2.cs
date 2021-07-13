using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume2 : MonoBehaviour {
    public Slider effectVolume;

    private float effectVol = 1f;

    // Use this for initialization
    void Start()
    {
        effectVol = PlayerPrefs.GetFloat("effectvol", 1f);
        effectVolume.value = effectVol;
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().volume = effectVolume.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().volume = effectVolume.value;
        effectVol = effectVolume.value;
        PlayerPrefs.SetFloat("effectvol", effectVol);
    }
}
