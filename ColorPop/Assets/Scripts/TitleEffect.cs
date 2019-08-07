using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffect : MonoBehaviour {

    public GameObject TitleObject;
    public GameObject TitleBaseImage;
    public float t;
    public float period;
    public int number;

	void Start () {
        TitleBaseImage.SetActive(true);
        TitleObject.SetActive(false);
        period = 2.5f;
        number = Random.Range(2, 5);
	}
	
	
	void Update () {
        t += Time.deltaTime;
        if(t >= period)
        {
            StartCoroutine(TitleEffectStart(number));
            t = 0f;
            period = Random.Range(3.5f, 6f);
            number = Random.Range(3, 5);
        }
	}

    IEnumerator TitleEffectStart(int Number)
    {
        TitleObject.SetActive(false);
        TitleBaseImage.SetActive(true);
        for (int i = 0; i < Number; i++)
        {
            yield return new WaitForSeconds(0.1f);
            TitleBaseImage.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            TitleBaseImage.SetActive(true);
        }
        TitleBaseImage.SetActive(false);
        TitleObject.SetActive(true);
    }
}
