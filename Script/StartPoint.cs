using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPoint : MonoBehaviour
{
    public string startPoint; //시작이 될 위치
    private PlayerMove pm;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    void Start()
    {
        pm = FindObjectOfType<PlayerMove>();

        if(startPoint == pm.currentMapName)
        {
            pm.transform.position = this.transform.position;
        }

        StartCoroutine(FadeIn());
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        PlayerMove.pm.isFadeIn = true;
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        Color alpha = Panel.color;

        yield return new WaitForSeconds(1f);
        time = 0f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        yield return null;
        PlayerMove.pm.isFadeIn = false;
    }

}
