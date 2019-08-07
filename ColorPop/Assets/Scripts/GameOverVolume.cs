using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("GameOver").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("Kwang").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);

        GameObject.Find("GameOverBgm").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("backvol", 1f);
    }
}
