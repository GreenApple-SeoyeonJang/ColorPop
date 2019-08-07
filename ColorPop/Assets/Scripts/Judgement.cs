using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judgement : MonoBehaviour {
    public Text ComboText;
    public static bool StopJudgement;//피버 직후 일시적으로 틀림 처리 X
    public GameObject ErrorPanel;
    public static int CurrentStarNumber;
    public int CurrentStarColor; //(1.빨강 2.파랑 3.노랑 4.하양 5.핑크 6.스카이 7.오렌지 8.초록 9.보라 10. 피버)
    public static int RedC, YellowC, BlueC, WhiteC, FeverC;

	void Start () {
        StopJudgement = false;
        CurrentStarNumber = 0;
        CurrentStarNumber = 0;
        RedC = 0;
        YellowC = 0;
        BlueC = 0;
        WhiteC = 0;
	}
	
	void Update ()
    {
        if (StopJudgement)
        {
            RedC = 0;
            BlueC = 0;
            YellowC = 0;
            WhiteC = 0;
        }

        if (CurrentStarNumber < SpawnManager.SpawnCount)
        {
            string CurrentStarName = "Star" + CurrentStarNumber.ToString();
            var CurrentStarProperty = GameObject.Find(CurrentStarName).GetComponent<StarProperty>();
            CurrentStarColor = CurrentStarProperty.MyColor;

            if (CurrentStarColor == 1) // 빨강
            {
                if (RedC == 1) //성공
                {
                    SuccessAndDestroy();
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0) // 아무것도 안누른 상태
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 2) // 파랑
            {
                if (BlueC == 1) //성공
                {
                    SuccessAndDestroy();
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 3) // 노랑
            {
                if (YellowC == 1) //성공
                {
                    SuccessAndDestroy();
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 4) // 하양
            {
                if (WhiteC == 1) //성공
                {
                    SuccessAndDestroy();
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 5) // 분홍
            {
                if (RedC == 1)
                {
                    SuccessAndChange(4);
                }
                else if (WhiteC == 1)
                {
                    SuccessAndChange(1);
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 6) // 하늘
            {
                if (WhiteC == 1)
                {
                    SuccessAndChange(2);
                }
                else if (BlueC == 1)
                {
                    SuccessAndChange(4);
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 7) // 주황
            {
                if (RedC == 1)
                {
                    SuccessAndChange(3);
                }
                else if (YellowC == 1)
                {
                    SuccessAndChange(1);
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 8) // 초록
            {
                if (YellowC == 1)
                {
                    SuccessAndChange(2);
                }
                else if (BlueC == 1)
                {
                    SuccessAndChange(3);
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 9) // 보라
            {
                if (RedC == 1)
                {
                    SuccessAndChange(2);
                }
                else if (BlueC == 1)
                {
                    SuccessAndChange(1);
                }
                else if (RedC == 0 && BlueC == 0 && YellowC == 0 && WhiteC == 0)
                {

                }
                else //실패
                {
                    Fail();
                }
            }

            else if (CurrentStarColor == 10) // 피버
            {
                if (FeverC >= 1)
                {
                    FeverSuccessAndDestroy();
                }
            }
        }
	}

    void SuccessAndDestroy()
    {
        string CurrentStarName = "Star" + CurrentStarNumber.ToString();
        var CurrentStarProperty = GameObject.Find(CurrentStarName).GetComponent<StarProperty>();

        RedC = 0;
        BlueC = 0;
        YellowC = 0;
        WhiteC = 0;

        CurrentStarProperty.PopEffectAndDestroy();
        CurrentStarNumber++;
        ScoreManager.ScoreApply(10);
        ScoreManager.AddCombo();
        FeverManager.AddFeverCombo();
        GameObject.Find("StarSound").GetComponent<AudioSource>().Play();
        var SCM = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        StartCoroutine(SCM.ShowCombo());
    }

    void SuccessAndChange(int ToChange)
    {
        string CurrentStarName = "Star" + CurrentStarNumber.ToString();
        var CurrentStarProperty = GameObject.Find(CurrentStarName).GetComponent<StarProperty>();

        RedC = 0;
        BlueC = 0;
        YellowC = 0;
        WhiteC = 0;

        StartCoroutine(CurrentStarProperty.ColorChangeEffect(ToChange));

        ScoreManager.ScoreApply(10);
        ScoreManager.AddCombo();
        FeverManager.AddFeverCombo();
        GameObject.Find("StarSound").GetComponent<AudioSource>().Play();
        var SCM = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        StartCoroutine(SCM.ShowCombo());
    }

    void FeverSuccessAndDestroy()
    {
        string CurrentStarName = "Star" + CurrentStarNumber.ToString();
        var CurrentStarProperty = GameObject.Find(CurrentStarName).GetComponent<StarProperty>();

        FeverC = 0;

        CurrentStarProperty.PopEffectAndDestroy();
        CurrentStarNumber++;
        ScoreManager.ScoreApply(20);
        ScoreManager.AddCombo();
        FeverManager.AddFeverCombo();
        GameObject.Find("StarSound").GetComponent<AudioSource>().Play();
        var SCM = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        StartCoroutine(SCM.ShowCombo());
    }

    void Fail()
    {
        StartCoroutine(Error());
        RedC = 0;
        BlueC = 0;
        YellowC = 0;
        WhiteC = 0;
        ScoreManager.ScoreApply(-5);
        ScoreManager.Combo = 0;
        FeverManager.FeverCount = 0;
        GameObject.Find("ErrorSound").GetComponent<AudioSource>().Play();
    }

    IEnumerator Error()
    {
        ErrorPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ErrorPanel.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        ErrorPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ErrorPanel.SetActive(false);
    }
}
