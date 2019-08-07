using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialToMenu : MonoBehaviour {
    AsyncOperation async_operation;
    int flag = 0; // 스타트 씬 로드 변수

    public void Start()
    {
      
    }
    public void Update()
    {
        if (flag == 0) // 로딩 하기 전(튜토리얼 키자마자 바로 스타트 씬 로딩 준비하기 위함)
        {
            async_operation = SceneManager.LoadSceneAsync("StartMenu");
            async_operation.allowSceneActivation = false;
            flag = 1; //로드 해놨음
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                async_operation.allowSceneActivation = true;
            }
        }
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        async_operation.allowSceneActivation = true;
    }
}
