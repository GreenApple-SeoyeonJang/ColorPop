using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonCount : MonoBehaviour {
    public static int redC, blueC, whiteC, yellowC;
   
	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RedClick()
    {
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
        redC++;
    }
    public void BlueClick()
    {
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
        blueC++;
    }
    public void Whitelick()
    {
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
        whiteC++;
    }
    public void YellowClick()
    {
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
        yellowC++;
    }
}
