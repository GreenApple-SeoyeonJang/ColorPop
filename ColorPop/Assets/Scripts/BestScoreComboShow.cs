using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BestScoreComboShow : MonoBehaviour {

    public Text NormalScore_Text;
    public Text NormalCombo_Text;

    public Text CrazyScore_Text;
    public Text CrazyCombo_Text; 

    void Start () {
        NormalScore_Text.text = PlayerPrefs.GetInt("BestNormalScore", 0).ToString();
        NormalCombo_Text.text = PlayerPrefs.GetInt("BestNormalCombo", 0).ToString();

        CrazyScore_Text.text = PlayerPrefs.GetInt("BestCrazyScore", 0).ToString();
        CrazyCombo_Text.text = PlayerPrefs.GetInt("BestCrazyCombo", 0).ToString();
    }
	
	void Update () {
		
	}
}
