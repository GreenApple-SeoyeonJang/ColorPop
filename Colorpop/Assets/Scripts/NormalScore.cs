using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NormalScore : MonoBehaviour
{

    public Text ScoreText; //글자 버전 점수 (글자 그 자체)
    public GameObject Score_Text_Version; // 글자 버전 점수 오브젝트
    public GameObject Score_Sprite_Version; //밑에 오브젝트 네개 묶어둔 거(점수 그림 버전)
    public GameObject Thousand, Hundred, Ten, One; //점수 천 백 십 일
    public Text CoinText;
    private SpriteRenderer myRenderer;
    public int coin;
    public Sprite zero, one, two, three, four, five, six, seven, eight, nine;

    IEnumerator Sound()
    {
        GameObject.Find("Kwang").GetComponent<AudioSource>().Play();
        GameObject.Find("GameOver").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.5f);
        GameObject.Find("GameOverBgm").GetComponent<AudioSource>().Play();
    }
    public void Awake()
    {
        coin = 0;
    }

    void Start()
    {
        StartCoroutine(Sound());
        ScoreManager.Score = ScoreManager.Score + (ScoreManager.BestCombo * 5); // 전체 점수는 마지막 점수 + (베스트콤보*5)
        coin = (ScoreManager.Score / 50);
        CoinText.text = coin.ToString();

        if (PlayerPrefs.GetInt("BestNormalCombo", 0) <= ScoreManager.BestCombo) //베스트 콤보 저장
            PlayerPrefs.SetInt("BestNormalCombo", ScoreManager.BestCombo);

        if (PlayerPrefs.GetInt("BestNormalScore", 0) <= ScoreManager.Score) //베스트 스코어 저장
            PlayerPrefs.SetInt("BestNormalScore", ScoreManager.Score);

        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + coin); // (점수/100) 코인 저장

        if (ScoreManager.Score > 9999) //점수 !!! 개잘했을 때 4자리수 넘으면...
        {
            ScoreText.text = ScoreManager.Score.ToString();
            Score_Text_Version.SetActive(true);
            Score_Sprite_Version.SetActive(false);
        }

        else if (ScoreManager.Score <= 9999) //9999이하 점수이면 그림으로 점수 표현
        {
            Score_Text_Version.SetActive(false);
            if (ScoreManager.Score < 1000) // 천보다 작으면 천자리는 안보여줌
                Thousand.SetActive(false);
            if (ScoreManager.Score < 100) // 백보다 작으면 백자리는 안보여줌
                Hundred.SetActive(false);
            if (ScoreManager.Score < 10)
                Ten.SetActive(false);

            myRenderer = Thousand.GetComponent<SpriteRenderer>(); //천자리 
            switch (ScoreManager.Score / 1000)
            {
                case 0:
                    myRenderer.sprite = zero;
                    break;
                case 1:
                    myRenderer.sprite = one;
                    break;
                case 2:
                    myRenderer.sprite = two;
                    break;
                case 3:
                    myRenderer.sprite = three;
                    break;
                case 4:
                    myRenderer.sprite = four;
                    break;
                case 5:
                    myRenderer.sprite = five;
                    break;
                case 6:
                    myRenderer.sprite = six;
                    break;
                case 7:
                    myRenderer.sprite = seven;
                    break;
                case 8:
                    myRenderer.sprite = eight;
                    break;
                case 9:
                    myRenderer.sprite = nine;
                    break;
            }

            myRenderer = Hundred.GetComponent<SpriteRenderer>(); //백자리 
            switch ((ScoreManager.Score % 1000) / 100)
            {
                case 0:
                    myRenderer.sprite = zero;
                    break;
                case 1:
                    myRenderer.sprite = one;
                    break;
                case 2:
                    myRenderer.sprite = two;
                    break;
                case 3:
                    myRenderer.sprite = three;
                    break;
                case 4:
                    myRenderer.sprite = four;
                    break;
                case 5:
                    myRenderer.sprite = five;
                    break;
                case 6:
                    myRenderer.sprite = six;
                    break;
                case 7:
                    myRenderer.sprite = seven;
                    break;
                case 8:
                    myRenderer.sprite = eight;
                    break;
                case 9:
                    myRenderer.sprite = nine;
                    break;
            }

            myRenderer = Ten.GetComponent<SpriteRenderer>(); //십자리 
            switch ((ScoreManager.Score % 100) / 10)
            {
                case 0:
                    myRenderer.sprite = zero;
                    break;
                case 1:
                    myRenderer.sprite = one;
                    break;
                case 2:
                    myRenderer.sprite = two;
                    break;
                case 3:
                    myRenderer.sprite = three;
                    break;
                case 4:
                    myRenderer.sprite = four;
                    break;
                case 5:
                    myRenderer.sprite = five;
                    break;
                case 6:
                    myRenderer.sprite = six;
                    break;
                case 7:
                    myRenderer.sprite = seven;
                    break;
                case 8:
                    myRenderer.sprite = eight;
                    break;
                case 9:
                    myRenderer.sprite = nine;
                    break;
            }

            myRenderer = One.GetComponent<SpriteRenderer>(); //일자리 
            switch (ScoreManager.Score % 10)
            {
                case 0:
                    myRenderer.sprite = zero;
                    break;
                case 1:
                    myRenderer.sprite = one;
                    break;
                case 2:
                    myRenderer.sprite = two;
                    break;
                case 3:
                    myRenderer.sprite = three;
                    break;
                case 4:
                    myRenderer.sprite = four;
                    break;
                case 5:
                    myRenderer.sprite = five;
                    break;
                case 6:
                    myRenderer.sprite = six;
                    break;
                case 7:
                    myRenderer.sprite = seven;
                    break;
                case 8:
                    myRenderer.sprite = eight;
                    break;
                case 9:
                    myRenderer.sprite = nine;
                    break;
            }
        }
    }
}
