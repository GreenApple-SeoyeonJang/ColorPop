using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonColor : MonoBehaviour {

    public UnityEngine.UI.Button Tutorial;
    float time = 0.0f;
    int flag = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update () {
        if (time <= 0)
            flag = 0; // 증가 플래그
        else if (time >= 0.8f)
            flag = 1; // 감소 플래그

        if (flag == 0) //버튼 색깔 원래 색
        {
            time += Time.deltaTime;
            Tutorial.image.color = new Color(255,255, 255, 0f);
        }
        else if (flag == 1) //버튼 색깔 빨간색
        {
            time -= Time.deltaTime;
            Tutorial.image.color = new Color(255, 0, 0, 0.1f);
        }
    }
}
