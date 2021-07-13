using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialProgram : MonoBehaviour {
    public ParticleSystem[] colors = new ParticleSystem[4];
    bool FilledChanged;
    bool WhoFirst; //혼합 색상에서 어떤 색을 먼저 선택했는지 확인, 마지막 누른 색에 따라 true 혹은 false가 저장됨
    public GameObject Ored, Oorange, Oyellow, Ogreen, Owhite, Opurple, Oblue, Opink, Osky;

    public Sprite red, blue, yellow, white, pink, sky, orange, green, purple;

    public Sprite fred, fblue, fyellow, fwhite, fpink, fsky, forange, fgreen, fpurple;
    public RuntimeAnimatorController Fred_ani, Fblue_ani, Fyellow_ani, Fwhite_ani, Fpink_ani, Fsky_ani, Forange_ani, Fgreen_ani, Fpurple_ani;

    public Sprite Pred, Pblue, Pyellow, Pwhite, Ppink, Psky, Porange, Pgreen, Ppurple;

    public GameObject blackhole;

    Vector3 TargetPosition;
    float delta, time = 0f;
    int flag = 0;
    int nblue = -1, nred = -1, nyellow = -1, nwhite = -1;
    int pink_white = -1, pink_red = -1, sky_blue = -1, sky_white = -1, orange_red = -1, orange_yellow = -1, green_yellow = -1, green_blue = -1, purple_red = -1, purple_blue = -1;
    public GameObject RedGuide, BlueGuide, WhiteGuide, YellowGuide;
    public GameObject redb, blueb, yellowb, whiteb;
    public GameObject greatjob;
    int current_star = 1; // 맨 앞 별은 filled그림으로 바꾸기 위함

    void ChangePopAndDestroy(GameObject name, int color, Vector3 Position) // 별 파괴 전, 터지는 이미지 잠깐 보여주고 삭제하기 위함
    {
        colors[color-1].gameObject.transform.position = Position;
        colors[color - 1].Clear();
        colors[color - 1].Play();
        Destroy(name);
    }

    void Start () {
        GameObject.Find("PBSound").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("effectvol", 1f);
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("backvol", 1f);
        TargetPosition = new Vector3(blackhole.transform.position.x, blackhole.transform.position.y, blackhole.transform.position.z);
        TutorialButtonCount.redC = 0;
        TutorialButtonCount.blueC = 0;
        TutorialButtonCount.yellowC = 0;
        TutorialButtonCount.whiteC = 0;
        FilledChanged = false;
        WhoFirst = false;
        RedGuide.SetActive(false);
        BlueGuide.SetActive(false);
        WhiteGuide.SetActive(false);
        YellowGuide.SetActive(false);
        greatjob.SetActive(false);
    }
	
	void Update () {
        this.delta += Time.deltaTime;

        if ((current_star == 2) && (FilledChanged == false))// 젤 앞에 별은 filled 그림으로 바꾸기 위함
        {
            FilledChanged = true;
            Oblue.GetComponent<SpriteRenderer>().sprite = fblue;
            Oblue.GetComponent<Animator>().runtimeAnimatorController = Fblue_ani;
        }
        else if ((current_star == 3) && (FilledChanged == false))
        {
            FilledChanged = true;
            Oyellow.GetComponent<SpriteRenderer>().sprite = fyellow;
            Oyellow.GetComponent<Animator>().runtimeAnimatorController = Fyellow_ani;
        }  
        else if ((current_star == 4) && (FilledChanged == false))
        {
            FilledChanged = true;
            Owhite.GetComponent<SpriteRenderer>().sprite = fwhite;
            Owhite.GetComponent<Animator>().runtimeAnimatorController = Fwhite_ani;
        }
        else if ((current_star == 5) && (FilledChanged == false))
        {
            FilledChanged = true;
            Opink.GetComponent<SpriteRenderer>().sprite = fpink;
            Opink.GetComponent<Animator>().runtimeAnimatorController = Fpink_ani;
        } 
        else if ((current_star == 6) && (FilledChanged == false))
        {
            FilledChanged = true;
            Osky.GetComponent<SpriteRenderer>().sprite = fsky;
            Osky.GetComponent<Animator>().runtimeAnimatorController = Fsky_ani;
        }
        else if ((current_star == 7) && (FilledChanged == false))
        {
            FilledChanged = true;
            Oorange.GetComponent<SpriteRenderer>().sprite = forange;
            Oorange.GetComponent<Animator>().runtimeAnimatorController = Forange_ani;
        }
        else if ((current_star == 8) && (FilledChanged == false))
        {
            FilledChanged = true;
            Ogreen.GetComponent<SpriteRenderer>().sprite = fgreen;
            Ogreen.GetComponent<Animator>().runtimeAnimatorController = Fgreen_ani;
        }   
        else if ((current_star == 9) && (FilledChanged == false))
        {
            FilledChanged = true;
            Opurple.GetComponent<SpriteRenderer>().sprite = fpurple;
            Opurple.GetComponent<Animator>().runtimeAnimatorController = Fpurple_ani;
        }
            

        if (Ored != null)
        {
            Ored.transform.position = Vector3.MoveTowards(Ored.transform.position, TargetPosition, 40 * Time.deltaTime);
            Ored.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
        }

        if(delta >= 1.5f)//파랑 출동
        {
            if (Oblue != null)
            {
                Oblue.transform.position = Vector3.MoveTowards(Oblue.transform.position, TargetPosition, 40 * Time.deltaTime);
                Oblue.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 3f)
        {
            if (Oyellow != null)
            {
                Oyellow.transform.position = Vector3.MoveTowards(Oyellow.transform.position, TargetPosition, 40 * Time.deltaTime);
                Oyellow.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 4.5f)
        {
            if (Owhite != null)
            {
                Owhite.transform.position = Vector3.MoveTowards(Owhite.transform.position, TargetPosition, 40 * Time.deltaTime);
                Owhite.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 6f)
        {
            if (Opink != null)
            {
                Opink.transform.position = Vector3.MoveTowards(Opink.transform.position, TargetPosition, 40 * Time.deltaTime);
                Opink.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 7.5f)
        {
            if (Osky != null)
            {
                Osky.transform.position = Vector3.MoveTowards(Osky.transform.position, TargetPosition, 40 * Time.deltaTime);
                Osky.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 9f)
        {
            if (Oorange != null)
            {
                Oorange.transform.position = Vector3.MoveTowards(Oorange.transform.position, TargetPosition, 40 * Time.deltaTime);
                Oorange.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 10.5f)
        {
            if (Ogreen != null)
            {
                Ogreen.transform.position = Vector3.MoveTowards(Ogreen.transform.position, TargetPosition, 40 * Time.deltaTime);
                Ogreen.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }
        if (delta >= 12f)
        {
            if (Opurple != null)
            {
                Opurple.transform.position = Vector3.MoveTowards(Opurple.transform.position, TargetPosition, 40 * Time.deltaTime);
                Opurple.transform.Rotate(new Vector3(0, 0, 250 * Time.deltaTime));
            }
        }


        if(current_star == 1) //없앨 별 빨강
        {
            if(Ored.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if(nred == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    nred = 0;
                }
                RedGuide.SetActive(true);
                if (TutorialButtonCount.redC == 1)
                {
                    RedGuide.SetActive(false);
                    ChangePopAndDestroy(Ored, 1, Ored.transform.localPosition);
                    current_star++;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 2) //없앨 별 파랑
        {
            if (Oblue.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (nblue == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    nblue = 0;
                }
                BlueGuide.SetActive(true);
                if (TutorialButtonCount.blueC == 1)
                {
                    BlueGuide.SetActive(false);
                    ChangePopAndDestroy(Oblue, 2, Oblue.transform.localPosition);
                    current_star++;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 3) //없앨 별 노랑
        {
            if (Oyellow.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (nyellow == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    nyellow = 0;
                }
                YellowGuide.SetActive(true);
                if (TutorialButtonCount.yellowC == 1)
                {
                    YellowGuide.SetActive(false);
                    ChangePopAndDestroy(Oyellow, 3, Oyellow.transform.localPosition);
                    current_star++;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 4) //없앨 별 하양
        {
            if (Owhite.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (nwhite == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    nwhite = 0;
                }
                WhiteGuide.SetActive(true);
                if (TutorialButtonCount.whiteC == 1)
                {
                    WhiteGuide.SetActive(false);
                    ChangePopAndDestroy(Owhite, 4, Owhite.transform.localPosition);
                    current_star++;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 5) //없앨 별 분홍
        {
            if (Opink.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (pink_red == -1 && pink_white == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    pink_red = 0;
                    pink_white = 0;
                }
                if (pink_white == 0)
                    WhiteGuide.SetActive(true);
                if (pink_red == 0)
                    RedGuide.SetActive(true);

                if (TutorialButtonCount.whiteC == 1)
                {
                    WhoFirst = false;
                    Opink.GetComponent<SpriteRenderer>().sprite = fred;
                    Opink.GetComponent<Animator>().runtimeAnimatorController = Fred_ani;
                    WhiteGuide.SetActive(false);
                    pink_white = 1;
                }
                else if (TutorialButtonCount.redC == 1)
                {
                    WhoFirst = true;
                    Opink.GetComponent<SpriteRenderer>().sprite = fwhite;
                    Opink.GetComponent<Animator>().runtimeAnimatorController = Fwhite_ani;
                    RedGuide.SetActive(false);
                    pink_red = 1;
                }
                if( pink_red == 1 && pink_white == 1)
                {
                    if (WhoFirst)
                        ChangePopAndDestroy(Opink, 1, Opink.transform.localPosition);
                    else
                        ChangePopAndDestroy(Opink, 4, Opink.transform.localPosition);
                    current_star++;
                    WhoFirst = false;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 6) //없앨 별 하늘
        {
            if (Osky.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (sky_blue == -1 && sky_white == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    sky_blue = 0;
                    sky_white = 0;
                }
                if (sky_white == 0)
                    WhiteGuide.SetActive(true);
                if (sky_blue == 0)
                    BlueGuide.SetActive(true);

                if (TutorialButtonCount.whiteC == 1)
                {
                    WhoFirst = false;
                    Osky.GetComponent<SpriteRenderer>().sprite = fblue;
                    Osky.GetComponent<Animator>().runtimeAnimatorController = Fblue_ani;
                    WhiteGuide.SetActive(false);
                    sky_white = 1;
                }
                else if (TutorialButtonCount.blueC == 1)
                {
                    WhoFirst = true;
                    Osky.GetComponent<SpriteRenderer>().sprite = fwhite;
                    Osky.GetComponent<Animator>().runtimeAnimatorController = Fwhite_ani;
                    BlueGuide.SetActive(false);
                    sky_blue = 1;
                }
                if (sky_white == 1 && sky_blue == 1)
                {
                    if (WhoFirst)
                        ChangePopAndDestroy(Osky, 2, Osky.transform.localPosition);
                    else
                        ChangePopAndDestroy(Osky, 4, Osky.transform.localPosition);
                    current_star++;
                    WhoFirst = false;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 7) //없앨 별 주황
        {
            if (Oorange.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (orange_red == -1 && orange_yellow == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    orange_red = 0;
                    orange_yellow = 0;
                }
                if (orange_red == 0)
                    RedGuide.SetActive(true);
                if (orange_yellow == 0)
                    YellowGuide.SetActive(true);

                if (TutorialButtonCount.redC == 1)
                {
                    WhoFirst = false;
                    Oorange.GetComponent<SpriteRenderer>().sprite = fyellow;
                    Oorange.GetComponent<Animator>().runtimeAnimatorController = Fyellow_ani;
                    RedGuide.SetActive(false);
                    orange_red = 1;
                }
                else if (TutorialButtonCount.yellowC == 1)
                {
                    WhoFirst = true;
                    Oorange.GetComponent<SpriteRenderer>().sprite = fred;
                    Oorange.GetComponent<Animator>().runtimeAnimatorController = Fred_ani;
                    YellowGuide.SetActive(false);
                    orange_yellow = 1;
                }
                if (orange_red == 1 && orange_yellow == 1)
                {
                    if (WhoFirst)
                        ChangePopAndDestroy(Oorange, 3, Oorange.transform.localPosition);
                    else
                        ChangePopAndDestroy(Oorange, 1, Oorange.transform.localPosition);
                    current_star++;
                    WhoFirst = false;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 8) //없앨 별 초록
        {
            if (Ogreen.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (green_blue == -1 && green_yellow == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    green_blue = 0;
                    green_yellow = 0;
                }
                if (green_yellow == 0)
                    YellowGuide.SetActive(true);
                if (green_blue == 0)
                    BlueGuide.SetActive(true);

                if (TutorialButtonCount.yellowC == 1)
                {
                    WhoFirst = false;
                    Ogreen.GetComponent<SpriteRenderer>().sprite = fblue;
                    Ogreen.GetComponent<Animator>().runtimeAnimatorController = Fblue_ani;
                    YellowGuide.SetActive(false);
                    green_yellow = 1;
                }
                else if (TutorialButtonCount.blueC == 1)
                {
                    WhoFirst = true;
                    Ogreen.GetComponent<SpriteRenderer>().sprite = fyellow;
                    Ogreen.GetComponent<Animator>().runtimeAnimatorController = Fyellow_ani;
                    BlueGuide.SetActive(false);
                    green_blue = 1;
                }
                if (green_yellow == 1 && green_blue == 1)
                {
                    if (WhoFirst)
                        ChangePopAndDestroy(Ogreen, 2, Ogreen.transform.localPosition);
                    else
                        ChangePopAndDestroy(Ogreen, 3, Ogreen.transform.localPosition);
                    WhoFirst = false;
                    current_star++;
                    Time.timeScale = 1;
                    FilledChanged = false;
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }

        if (current_star == 9) //없앨 별 보라
        {
            if (Opurple.transform.position.y <= 0)
            {
                Time.timeScale = 0;
                if (purple_red == -1 && purple_blue == -1)
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                    purple_red = 0;
                    purple_blue = 0;
                }
                if (purple_red == 0)
                    RedGuide.SetActive(true);
                if (purple_blue == 0)
                    BlueGuide.SetActive(true);

                if (TutorialButtonCount.redC == 1)
                {
                    WhoFirst = false;
                    Opurple.GetComponent<SpriteRenderer>().sprite = fblue;
                    Opurple.GetComponent<Animator>().runtimeAnimatorController = Fblue_ani;
                    RedGuide.SetActive(false);
                    purple_red = 1;
                }
                else if (TutorialButtonCount.blueC == 1)
                {
                    WhoFirst = true;
                    Opurple.GetComponent<SpriteRenderer>().sprite = fred;
                    Opurple.GetComponent<Animator>().runtimeAnimatorController = Fred_ani;
                    BlueGuide.SetActive(false);
                    purple_blue = 1;
                }
                if (purple_red == 1 && purple_blue == 1)
                {
                    if (WhoFirst)
                        ChangePopAndDestroy(Opurple, 2, Opurple.transform.localPosition);
                    else
                        ChangePopAndDestroy(Opurple, 1, Opurple.transform.localPosition);
                    WhoFirst = false;
                    current_star++;
                    Time.timeScale = 1;
                    blackhole.SetActive(false);
                    redb.SetActive(false);
                    blueb.SetActive(false);
                    whiteb.SetActive(false);
                    yellowb.SetActive(false);
                    greatjob.SetActive(true);
                }
                else
                {
                    TutorialButtonCount.redC = 0;
                    TutorialButtonCount.blueC = 0;
                    TutorialButtonCount.whiteC = 0;
                    TutorialButtonCount.yellowC = 0;
                }
            }
        }
        if(greatjob.activeSelf == true)
        {
            if (time <= 0)
                flag = 0; // 증가 플래그
            else if (time >= 0.5f)
                flag = 1; // 감소 플래그

            if (flag == 0) //글자 색깔 원래 색
            {
                time += Time.deltaTime;
                greatjob.GetComponent<Image>().color = new Color(255, 255, 255);
            }
            else if (flag == 1) //버튼 색깔 빨간색
            {
                time -= Time.deltaTime;
                greatjob.GetComponent<Image>().color = new Color(0,0 ,0);
            }
        }
    }
}
