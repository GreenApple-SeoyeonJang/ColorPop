using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StarProperty : MonoBehaviour {
    public string SceneName;
    public ParticleSystem[] colors = new ParticleSystem[6];
    public Vector3 OriginalStarScale;
    public Vector3 BigStarScale;
    public int MyNumber;
    public int MyColor; //색깔 범위 (1.빨강 2.파랑 3.노랑 4.하양 5.핑크 6.스카이 7.오렌지 8.초록 9.보라 10. 피버)
    public Sprite red, blue, yellow, white,  pink,  sky, orange, green, purple, fever;
    public RuntimeAnimatorController red_ani, blue_ani, yellow_ani, white_ani, pink_ani, sky_ani, orange_ani, green_ani, purple_ani, fever_ani;
    public Sprite Fred, Fblue, Fyellow, Fwhite, Fpink, Fsky, Forange, Fgreen, Fpurple;
    public RuntimeAnimatorController Fred_ani, Fblue_ani, Fyellow_ani, Fwhite_ani, Fpink_ani, Fsky_ani, Forange_ani, Fgreen_ani, Fpurple_ani;
    public float MySpeed;
    public SpriteRenderer MR;
    public Animator MA;
    Vector3 BlackholePosition;

    void Start() {
        OriginalStarScale = GameObject.Find("OriginalStar").transform.localScale;
        BlackholePosition = GameObject.Find("Blackhole").GetComponent<Transform>().localPosition;
        MR = this.GetComponent<SpriteRenderer>();
        MA = this.GetComponent<Animator>();
        BigStarScale = OriginalStarScale * 1.4f;
        SceneName = SceneManager.GetActiveScene().name;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, BlackholePosition, MySpeed * Time.deltaTime);
        this.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
        if (MyNumber == Judgement.CurrentStarNumber) // 맨 앞의 별은 채워진 색
        {
            if (FeverManager.IsFeverMode == false)
            {
                if (MyColor == 1)
                {
                    MR.sprite = Fred;
                    MA.runtimeAnimatorController = Fred_ani;
                }  
                else if (MyColor == 2)
                {
                    MR.sprite = Fblue;
                    MA.runtimeAnimatorController = Fblue_ani;
                }
                else if (MyColor == 3)
                {
                    MR.sprite = Fyellow;
                    MA.runtimeAnimatorController = Fyellow_ani;
                }   
                else if (MyColor == 4)
                {
                    MR.sprite = Fwhite;
                    MA.runtimeAnimatorController = Fwhite_ani;
                }  
                else if (MyColor == 5)
                {
                    MR.sprite = Fpink;
                    MA.runtimeAnimatorController = Fpink_ani;
                } 
                else if (MyColor == 6)
                {
                    MR.sprite = Fsky;
                    MA.runtimeAnimatorController = Fsky_ani;
                } 
                else if (MyColor == 7)
                {
                    MR.sprite = Forange;
                    MA.runtimeAnimatorController = Forange_ani;
                }
                else if (MyColor == 8)
                {
                    MR.sprite = Fgreen;
                    MA.runtimeAnimatorController = Fgreen_ani;
                } 
                else if (MyColor == 9)
                {
                    MR.sprite = Fpurple;
                    MA.runtimeAnimatorController = Fpurple_ani;
                }    
            }
        }

        if (this.transform.position == BlackholePosition) // 별이 블랙홀에 왔을 때
        {
            if(SceneName == "CrazyNeon")
                SceneManager.LoadScene("CrazyGameOverScene");
            else if(SceneName == "CrazyPastel")
                SceneManager.LoadScene("CrazyGameOverScene");
            else if (SceneName == "NormalNeon")
                SceneManager.LoadScene("NormalGameOverScene");
            else if (SceneName == "NormalPastel")
                SceneManager.LoadScene("NormalGameOverScene");
        }
    }

    public void StarSpriteChange()
    {
        if (MyColor == 1)
        {
            MR.sprite = red;
            MA.runtimeAnimatorController = red_ani;
        }
        else if (MyColor == 2)
        {
            MR.sprite = blue;
            MA.runtimeAnimatorController = blue_ani;
        }
        else if (MyColor == 3)
        {
            MR.sprite = yellow;
            MA.runtimeAnimatorController = yellow_ani;
        }
        else if (MyColor == 4)
        {
            MR.sprite = white;
            MA.runtimeAnimatorController = white_ani;
        }
        else if (MyColor == 5)
        {
            MR.sprite = pink;
            MA.runtimeAnimatorController = pink_ani;
        }
        else if (MyColor == 6)
        {
            MR.sprite = sky;
            MA.runtimeAnimatorController = sky_ani;
        }
        else if (MyColor == 7)
        {
            MR.sprite = orange;
            MA.runtimeAnimatorController = orange_ani;
        }
        else if (MyColor == 8)
        {
            MR.sprite = green;
            MA.runtimeAnimatorController = green_ani;
        }
        else if (MyColor == 9)
        {
            MR.sprite = purple;
            MA.runtimeAnimatorController = purple_ani;
        }
        else if (MyColor == 10)
        {
            MR.sprite = fever;
            MA.runtimeAnimatorController = fever_ani;
        }
    }

    public void PopEffectAndDestroy() // 별 파괴 전, 터지는 이미지 잠깐 보여주고 삭제하기 위함
    {
        if(MyColor == 10)
        {
            if((MyNumber % 2) == 0)
            {
                colors[4].gameObject.transform.position = this.transform.localPosition;
                colors[4].Clear();
                colors[4].Play();
            }
            else
            {
                colors[5].gameObject.transform.position = this.transform.localPosition;
                colors[5].Clear();
                colors[5].Play();
            }
        }
        else
        {
            colors[MyColor - 1].gameObject.transform.position = this.transform.localPosition;
            colors[MyColor - 1].Clear();
            colors[MyColor - 1].Play();
        }
        Destroy(GameObject.Find("Star" + MyNumber));
    }

    public IEnumerator ColorChangeEffect(int ToChange)
    {
        this.transform.localScale = BigStarScale;
        yield return new WaitForSeconds(0.008f);
        MyColor = ToChange;
        StarSpriteChange();
        this.transform.localScale = OriginalStarScale;
    }
}
