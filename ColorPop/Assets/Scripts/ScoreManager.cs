using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text ScoreText;
    public Text ComboText;
    public GameObject ComboObject;
    public static int Score; // 게임 점수
    public static int BestCombo; //제일 높은 콤보 저장
    public static int Combo; // 현재 콤보 숫자 기억

    void Start () {
        Score = 0;
        BestCombo = 0;
        Combo = 0;
        ComboObject.SetActive(false);
	}
	
	void Update () {
        ScoreText.text = Score.ToString();
        if (Score <= 0)
            Score = 0;
        if (Combo >= BestCombo)
            BestCombo = Combo;
	}
    public static void ScoreApply(int value)
    {
        Score = Score + value;
    }

    public static void AddCombo()
    {
        Combo++;
    }

    public IEnumerator ShowCombo()
    {
        if (Combo > 0)
        {
            ComboText.text = Combo.ToString() + " Combo";
            ComboObject.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            ComboObject.SetActive(false);
        }
    }
}
