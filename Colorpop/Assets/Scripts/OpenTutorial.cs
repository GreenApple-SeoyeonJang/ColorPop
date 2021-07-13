using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OpenTutorial : MonoBehaviour {
    int flag = 0; //튜토리얼 씬 로딩 변수
    AsyncOperation async_operation;

	
	// Update is called once per frame
	void Update () {
        if (flag == 0) // 로딩 하기 전(스타트 키자마자 바로 튜토리얼 씬 로딩 준비하기 위함)
        {
            async_operation = SceneManager.LoadSceneAsync("Tutorial");
            async_operation.allowSceneActivation = false;
            flag = 1; //로드 해놨음
        }
    }

    public void openTutorial()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Tutorial");
    }
}
