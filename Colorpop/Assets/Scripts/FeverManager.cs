using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeverManager : MonoBehaviour {
    
    public static bool IsFeverMode;
    public static int FeverCount;
    public GameObject FeverSliderObject;
    public Slider FeverSlider;
    public GameObject NormalButtons, FeverButtons;
    public GameObject NormalBackgroundParticle, FeverBackgroundParticle;
    public AudioSource FeverSound, FireSound;
    public static int FeverNumber; // 몇 개 동안 피버 (시간 지날수록 피버 개수 증가함)
    public int FeverCutLine; // 몇 개 넘어야지 피버 시작하는가 (시간 지날수록 커트라인 올라감)

    void Start () {
        FeverSound = GameObject.Find("FeverSound").GetComponent<AudioSource>();
        FireSound = GameObject.Find("FireSound").GetComponent<AudioSource>();
        FeverCutLine = 20;
        FeverNumber = 20;
        FeverSliderObject.SetActive(false);
        IsFeverMode = false;
        FeverCount = 0;
        NormalButtons.SetActive(true);
        FeverButtons.SetActive(false);
        NormalBackgroundParticle.SetActive(true);
        FeverBackgroundParticle.SetActive(false);
	}
	
	void Update () {
        if (SpawnManager.SpawnCount <= 5) //게임 초반에는 피버 x
            FeverCount = 0;
        else
        {
            FeverSlider.value = (FeverCount - (float)FeverCutLine) / FeverNumber;
            if ((FeverCount >= FeverCutLine) && (IsFeverMode == false)) //FeverLine 개수 만큼 틀리지 않고 맞췄을 때 피버 시작
            {
                FeverSound.Play();
                FireSound.Play();

                NormalBackgroundParticle.SetActive(false);
                FeverBackgroundParticle.SetActive(true);
                FeverSliderObject.SetActive(true);
                IsFeverMode = true;

                Judgement.RedC = 0;
                Judgement.BlueC = 0;
                Judgement.YellowC = 0;
                Judgement.WhiteC = 0;
                Judgement.FeverC = 0;

                for (int i = Judgement.CurrentStarNumber; i <= SpawnManager.SpawnCount; i++) //피버 시작하기 전 남은 별 삭제
                {
                    Destroy(GameObject.Find("Star" + i));
                    Judgement.CurrentStarNumber++;
                    ScoreManager.ScoreApply(10);
                }

                Judgement.CurrentStarNumber--;
                NormalButtons.SetActive(false);
                FeverButtons.SetActive(true);
            }
            else if (FeverCount > FeverCutLine + FeverNumber) //피버 종료
            {
                GameObject.Find("FireSound").GetComponent<AudioSource>().Stop();
                NormalBackgroundParticle.SetActive(true);
                FeverBackgroundParticle.SetActive(false);
                FeverSliderObject.SetActive(false);
                IsFeverMode = false;
                Judgement.StopJudgement = true;
                SpawnManager.time -= 1f;
                SpawnManager.FeverSpawnCount = 0; //변수 초기화
                FeverNumber++; //피버 개수 증가
                FeverCutLine++; //피버 커트라인 증가
                NormalButtons.SetActive(true);
                FeverButtons.SetActive(false);
                FeverCount = 0;
            }
        }
	}

    public static void AddFeverCombo()
    {
        FeverCount++;
    }
}
