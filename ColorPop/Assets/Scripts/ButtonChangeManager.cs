using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeManager : MonoBehaviour {
    public Vector3[] ButtonLocation = new Vector3[4];
    public Quaternion[] ButtonRotation = new Quaternion[4];
    public GameObject[] Buttons = new GameObject[4];
    public GameObject ButtonObject;
    public AudioSource AS;
    public float ChangeTime;
    public float t;
    public int temp;
    public int[] check = new int[4];

	void Start () {
        AS = this.GetComponent<AudioSource>();
        ChangeTime = 20f;
        t = 0f;
        for (int i =0; i < 4; i++)
        {
            GameObject temp = GameObject.Find("Button" + i);
            ButtonLocation[i] = temp.transform.position;
            ButtonRotation[i] = temp.transform.rotation;
        }
	}
	
	void Update () {
        t += Time.deltaTime;
        if (t >= ChangeTime)
        {
            if (!FeverManager.IsFeverMode)
            {
                t = -1f;
                SpawnManager.time = -1.0f - (0.5f / SpawnManager.SpawnPeriod);
                StartCoroutine(ChangeStart());
                ChangeTime = ChangeTime - 0.5f;
            }
        }
        if(ChangeTime < 5f)
            ChangeTime = 5f;
    }

    IEnumerator ChangeStart()
    {
        yield return new WaitForSeconds(2.1f);
        while (FeverManager.IsFeverMode) // 피버모드때 버튼 체인지 이중 방지
        {
            t = -1f;
            yield return null;
        }
        ButtonObject.SetActive(false);
        yield return new WaitForSeconds(0.07f);
        while (FeverManager.IsFeverMode) // 피버모드때 버튼 체인지 이중 방지
        {
            t = -1f;
            yield return null;
        }
        ButtonObject.SetActive(true);
        yield return new WaitForSeconds(0.07f);
        ButtonObject.SetActive(false);
        yield return new WaitForSeconds(0.07f);
        while (FeverManager.IsFeverMode) // 피버모드때 버튼 체인지 이중 방지
        {
            t = -1f;
            yield return null;
        }
        ButtonObject.SetActive(true);
        yield return new WaitForSeconds(0.07f);
        ButtonObject.SetActive(false);
        yield return new WaitForSeconds(0.07f);
        while (FeverManager.IsFeverMode) // 피버모드때 버튼 체인지 이중 방지
        {
            t = -1f;
            yield return null;
        }
        ButtonObject.SetActive(true);
        yield return new WaitForSeconds(0.07f);
        ButtonObject.SetActive(false);
        yield return new WaitForSeconds(0.07f);
        while (FeverManager.IsFeverMode) // 피버모드때 버튼 체인지 이중 방지
        {
            t = -1f;
            yield return null;
        }
        ButtonObject.SetActive(true);
        AS.Play();

        temp = check[0]; // 하나는 무조건 바뀌게 하기 위함
        check[0] = Random.Range(0, 4);
        while(check[0] == temp)
            check[0] = Random.Range(0, 4);

        Buttons[0].transform.position = ButtonLocation[check[0]];
        Buttons[0].transform.rotation = ButtonRotation[check[0]];

        check[1] = Random.Range(0, 4);
        while (check[1] == check[0])
        {
            check[1] = Random.Range(0, 4);
        }
        Buttons[1].transform.position = ButtonLocation[check[1]];
        Buttons[1].transform.rotation = ButtonRotation[check[1]];

        check[2] = Random.Range(0, 4);
        while ((check[2] == check[0]) || (check[2] == check[1]))
        {
            check[2] = Random.Range(0, 4);
        }
        Buttons[2].transform.position = ButtonLocation[check[2]];
        Buttons[2].transform.rotation = ButtonRotation[check[2]];

        check[3] = Random.Range(0, 4);
        while ((check[3] == check[0]) || (check[3] == check[1]) || (check[3] == check[2]))
        {
            check[3] = Random.Range(0, 4);
        }
        Buttons[3].transform.position = ButtonLocation[check[3]];
        Buttons[3].transform.rotation = ButtonRotation[check[3]];
    }
}
