using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManage : MonoBehaviour {
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("PBSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("StarSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("ErrorSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("FeverSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("FireSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("backvol", 1f);
    }
}
