using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager3 : MonoBehaviour
{
    public GameObject quizPanel;
    public bool isCorrect;
    public GameObject corImg;
    public GameObject wroImg;
    public string sceneName;
    public GameObject Map3Potal;
    public GameObject Obstacle;
    public GameObject NPCH;
    public AudioSource CorSound;
    public AudioSource WroSound;


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
        NPCH.SetActive(false);
        Obstacle.SetActive(false);
        Map3Potal.SetActive(true);
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
        NPCH.SetActive(true);
        quizPanel.SetActive(false);
        QuizManager.QM.isQuizOpen = false;

    }

    IEnumerator printWrong()
    {
        wroImg.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        wroImg.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        NPCH.SetActive(true);
        quizPanel.SetActive(false);
        QuizManager.QM.isQuizOpen = false;
    }
}
