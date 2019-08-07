using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuStarsEffect : MonoBehaviour {
    public SpriteRenderer StarImage;
    float RandomFadeTime;
    float time = 0.0f;
    int flag = 0;
    int RandomLeftRightRotate;
    float fades = 0.0f;

    public void Awake()
    {
        RandomFadeTime = Random.Range(1f, 5f);
        RandomLeftRightRotate = Random.Range(1, 3);
    }
    // Use this for initialization
    void Start () {
        StarImage = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if(RandomLeftRightRotate == 1)
            this.transform.Rotate(new Vector3(0, 0, 55 * Time.deltaTime * RandomFadeTime));
        else
            this.transform.Rotate(new Vector3(0, 0, -55 * Time.deltaTime * RandomFadeTime)); // 반대로 회전
        if (time <= 0)
            flag = 0; // 증가 플래그
        else if (time >= RandomFadeTime)
            flag = 1; // 감소 플래그

        if (flag == 0) //별 색깔 진해짐
        {
            time += Time.deltaTime;
            fades += 0.01f;
            StarImage.color = new Color(255, 255, 255, fades);
        }
        else if (flag == 1) //별 색깔 어두워짐
        {
            time -= Time.deltaTime;
            fades -= 0.01f;
            StarImage.color = new Color(255, 255, 255, fades);
        }
    }
}
