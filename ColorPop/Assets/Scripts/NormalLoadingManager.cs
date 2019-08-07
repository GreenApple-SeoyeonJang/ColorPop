using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormalLoadingManager : MonoBehaviour {

    public Slider slider;
    float fTime;
    AsyncOperation async_operation;

    void Awake()
    {
        fTime = 0f;
    }

    void Start()
    {
        Time.timeScale = 1;
        if(PlayerPrefs.GetInt("ThemePick" , 0) == 0)
            StartLoad("NormalNeon");
        else
            StartLoad("NormalPastel");
    }

    void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime / 3.5f;

        if (fTime >= 3.5f)
        {
            async_operation.allowSceneActivation = true;
        }
    }

    public void StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;
    }
}