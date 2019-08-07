using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyThemeCoin : MonoBehaviour {
    public GameObject NotEnoughCoinPanel;
    public GameObject pastelTheme;
    public GameObject neonTheme;
    public GameObject neonNotActive;
    public GameObject pastelCannotBuy;
    public GameObject pastelNotActive;
    public Text CoinText;

	// Use this for initialization
	void Start () {
        NotEnoughCoinPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        CoinText.text = PlayerPrefs.GetInt("Coin",0).ToString();
		if(PlayerPrefs.GetInt("PastelActive" , 0) == 0) //안샀음
        {
            neonTheme.SetActive(true);
            pastelCannotBuy.SetActive(true);
            pastelTheme.SetActive(false);
            neonNotActive.SetActive(false);
            pastelNotActive.SetActive(false);
        }
        else if((PlayerPrefs.GetInt("PastelActive" , 0) == 1) && (PlayerPrefs.GetInt("ThemePick",0) == 0 )) //샀고 네온 고른 상태
        {
            neonTheme.SetActive(true);
            pastelCannotBuy.SetActive(false);
            pastelTheme.SetActive(false);
            neonNotActive.SetActive(false);
            pastelNotActive.SetActive(true);
        }
        else if ((PlayerPrefs.GetInt("PastelActive", 0) == 1) && (PlayerPrefs.GetInt("ThemePick", 0) == 1)) //샀고 파스텔 고른 상태
        {
            neonTheme.SetActive(false);
            pastelCannotBuy.SetActive(false);
            pastelTheme.SetActive(true);
            neonNotActive.SetActive(true);
            pastelNotActive.SetActive(false);
        }
    }
}
