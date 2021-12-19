using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public bool isCorrect;
    public GameObject NpcMark1000;
    public string sceneName;
    public bool isQuizOpen;
    public GameObject NPCB;
    public GameObject NPCA;
    public AudioSource CorSound;
    public AudioSource WroSound;
    public GameObject CorImg;
    public GameObject WorImg;

    public static QuizManager QM;
    public void Awake()
    {
        if (QM == null)
        {
           QM = this;
        }

        NpcMark1000.SetActive(false);
        isQuizOpen = false;
    }

    public void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void panelQuit()
    {
        quizPanel.SetActive(false);
        PlayerMove.pm.speed = 6;
        isQuizOpen = false;
        NPCA.SetActive(true);
    }

    public void Correct()
    {
        CorSound.Play();
        isCorrect = true;
        if(sceneName == "Map1")
            Destroy(NpcMark1000);
        StartCoroutine("printCorrect");
        NPCB.SetActive(true);
    }

    public void Wrong()
    {
        WroSound.Play();
        isCorrect = false;       
        StartCoroutine("printWrong");
    }

    IEnumerator printCorrect()
    {
        CorImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        CorImg.SetActive(false);
        yield return new WaitForSeconds(0.5f);       
        quizPanel.SetActive(false);
        isQuizOpen = false;
        NPCA.SetActive(true);

    }

    IEnumerator printWrong()
    {
        WorImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        WorImg.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        quizPanel.SetActive(false);
        isQuizOpen = false;
        NPCA.SetActive(true);
    }
}
