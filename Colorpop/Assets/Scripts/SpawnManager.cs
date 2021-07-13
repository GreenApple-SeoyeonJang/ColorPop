using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//별 생성 스크립트
public class SpawnManager : MonoBehaviour {
    public GameObject OriginalStar;
    public GameObject Blackhole;
    int radius;
    public static float time;
    public static int SpawnCount;
    public static int FeverSpawnCount;//정해진 피버 개수만큼만 별 생성, 초기화는 FeverManager가 담당
    public static float SpawnPeriod;
    public float FeverSpawnPeriod;
    public float SpawnSpeed;
    public float FeverSpawnSpeed; 
    
	void Start () {
        radius = 16;
        time = 0.0f;
        SpawnCount = 0;
        SpawnPeriod = 1.5f;
        FeverSpawnPeriod = 0.20f;
        SpawnSpeed = 40f;
        FeverSpawnSpeed = 97f;
        FeverSpawnCount = 0;
    }
	
	void Update () {
        time += Time.deltaTime;
        if (FeverManager.IsFeverMode)
        {
            if (FeverSpawnCount <= FeverManager.FeverNumber)
            {
                if (time >= FeverSpawnPeriod)
                {
                    time = 0f;
                    StarSpawn();
                    FeverSpawnCount++;
                }
            }
        }
        else
        {
            if (time >= SpawnPeriod)
            {
                time = 0f;
                StarSpawn();
            }
        }
	}

    void StarSpawn()
    {
        float px = Random.Range(Blackhole.transform.position.x - radius + 1, Blackhole.transform.position.x + radius - 1); //x랜덤 생성(블랙홀 기준 - 거리 ~ 블랙홀 기준 + 거리)너무 양끝 아니도록 쁠마 1함
        float py;
        py = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(px, 2));

        GameObject NewStar = Instantiate(OriginalStar) as GameObject;
        NewStar.transform.position = new Vector2(px, py);
        string StarName = "Star" + SpawnCount.ToString();
        NewStar.name = StarName;

        var SP = GameObject.Find(StarName).GetComponent<StarProperty>();
        if(FeverManager.IsFeverMode == true)
        {
            SP.MySpeed = FeverSpawnSpeed;
            SP.MyColor = 10;
        }
        else
        {
            SP.MySpeed = SpawnSpeed;
            SP.MyColor = StarColor();
            UpdateSpeed();
            UpdatePeriod();
        }
        SP.MyNumber = SpawnCount;
        SP.StarSpriteChange();
        SpawnCount++;
        Judgement.StopJudgement = false;
    }

    int StarColor() //색깔 범위 (1.빨강 2.파랑 3.노랑 4.하양 5.핑크 6.스카이 7.오렌지 8.초록 9.보라 10. 피버)
    {
        if (SpawnCount <= 7)
            return Random.Range(1, 5);
        else if (SpawnCount <= 20)
            return Random.Range(1, 7);
        else
            return Random.Range(1, 10);
    }

    void UpdateSpeed()
    {
        if (SpawnSpeed >= 61f) //별이 다가오는 속도 제한
            SpawnSpeed = 61f;
        SpawnSpeed = SpawnSpeed + 0.34f;
    }

    void UpdatePeriod()
    {
        if (SpawnPeriod <= 0.5f) //별 생성 속도 제한
            SpawnPeriod = 0.5f;
        
        SpawnPeriod = SpawnPeriod - 0.007f;
    }
}


