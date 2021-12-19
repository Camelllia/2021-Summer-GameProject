using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager2 : MonoBehaviour
{
    public GameObject quizPanel;
    public bool isCorrect;
    public GameObject corImg;
    public GameObject worImg;
    public string sceneName;
    public GameObject NPCD; //æÁ√ 
    public AudioSource CorSound;
    public AudioSource WroSound;
    public GameObject NPCC;

    public void Awake()
    {
        
    }

    public void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void panelQuit()
    {
        quizPanel.SetActive(false);
        
        PlayerMove.pm.speed = 6;
        QuizManager.QM.isQuizOpen = false;
    }

    public void Correct()
    {
        CorSound.Play();
        isCorrect = true;
        StartCoroutine("printCorrect");
        NPCD.SetActive(true);
    }

    public void Wrong()
    {
        WroSound.Play();
        isCorrect = false;
        StartCoroutine("printWrong");
    }

    IEnumerator printCorrect()
    {
        corImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        corImg.SetActive(false);
        yield return new WaitForSeconds(0.5f);        
        quizPanel.SetActive(false);
        QuizManager.QM.isQuizOpen = false;
        NPCC.SetActive(false);

    }

    IEnumerator printWrong()
    {
        worImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        worImg.SetActive(false);
        yield return new WaitForSeconds(0.5f);       
        quizPanel.SetActive(false);
        QuizManager.QM.isQuizOpen = false;
        NPCC.SetActive(true);
    }
}
