using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class LeaderBoard : MonoBehaviour {
    public UnityEngine.UI.Button Trophy;
    float time = 0.0f;
    int flag = 0;

	// Update is called once per frame
	void Update () {
        if (time <= 0)
            flag = 0; // 증가 플래그
        else if (time >= 0.6f)
            flag = 1; // 감소 플래그

        if (flag == 0) //버튼 색깔 원래 색
        {
            time += Time.deltaTime;
            Trophy.image.color = new Color(255, 255, 255);
        }
        else if (flag == 1) //버튼 색깔 빨간색
        {
            time -= Time.deltaTime;
            Trophy.image.color = new Color(255, 240, 0);
        }
    }

    public void Ranking()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate(AuthenticateHandler);
    }

    void AuthenticateHandler(bool isSuccess)
    {
        if (isSuccess)
        {
            int NormalBestScore = PlayerPrefs.GetInt("BestNormalScore", 0);
            int CrazyBestScore = PlayerPrefs.GetInt("BestCrazyScore", 0);

            Social.ReportScore((long)CrazyBestScore, "CgkI04v94b4UEAIQBg", (bool success) =>
            {
                if (success)
                {

                }
                else
                {
                    // failed
                }
            });

            Social.ReportScore((long)NormalBestScore, "CgkI04v94b4UEAIQAA", (bool success) =>
            {
                 if (success)
                 {
                     PlayGamesPlatform.Instance.ShowLeaderboardUI();
                 }
                 else
                 {
                     // failed
                 }
             });

        }
        else
        {
            //login failed
        }
    }
    }
