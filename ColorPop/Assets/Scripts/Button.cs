using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject Me;
    public float x, y;
    public float divx, divy;

    private void Start()
    {
        Me = this.gameObject;
        x = Me.transform.localScale.x;
        y = Me.transform.localScale.y;
        divx = x / 35f;
        divy = y / 35f;
    }

    public void RedC()
    {
        StartCoroutine(ClickAniStart(0));
        Judgement.RedC++;
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
    }

    public void YellowC()
    {
        StartCoroutine(ClickAniStart(2));
        Judgement.YellowC++;
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
    }

    public void BlueC()
    {
        StartCoroutine(ClickAniStart(1));
        Judgement.BlueC++;
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
    }

    public void WhiteC()
    {
        StartCoroutine(ClickAniStart(3));
        Judgement.WhiteC++;
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
    }

    public void FeverC1()
    {
        StartCoroutine(ClickAniStart(4));
        Judgement.FeverC++;
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
    }

    public void FeverC2()
    {
        StartCoroutine(ClickAniStart(5));
        Judgement.FeverC++;
        GameObject.Find("PBSound").GetComponent<AudioSource>().Play();
    }

    private IEnumerator ClickAniStart(int Number)
    {
        for (int i = 0; i <= 5; i++)
        {
            Me.transform.localScale = new Vector2(x - (divx * i), y - (divy * i));
            yield return (0.00005f);
        }

        for (int i = 5; i >= 0; i--)
        {
            Me.transform.localScale = new Vector2(x - (divx * i), y - (divy * i));
            yield return (0.00005f);
        }
    }
}
