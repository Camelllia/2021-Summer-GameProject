using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene1Manager : MonoBehaviour
{  
    public TypeEffect talk;
    public GameObject scanObject;
    public bool isAction;
    public TalkManager talkManager;
    public int talkIndex;
    public Image PortraitImg;
    public Animator talkPanel;
    public GameObject quizPanel;
    public GameObject quizPanel2;
    public GameObject InGameOption;
    public bool isOpen;
    public Image nameImg;
    public Image Panel; // 페이드인/아웃 패널
    float time = 0f;
    float F_time = 1f;
    public GameObject Dark;
    public GameObject Dark2;
    public GameObject Ma1Potal;
    public GameObject Ma2Potal;
    public GameObject Map3Potal;
    public GameObject NPCB;
    public GameObject letterPanel;
    public GameObject birdPanel;
    public GameObject quizPanel3;
    public GameObject NPCH;
    public GameObject NPCA;
    public GameObject BG;
    public GameObject Obs2;
    public GameObject NPCC;
    

    public void Awake()
    {
        isOpen = false;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOpen == false)
        {
            InGameOption.SetActive(true);
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true)
        {
            InGameOption.SetActive(false);
            isOpen = false;
        }
            
        if(isOpen == false && !QuizManager.QM.isQuizOpen)
        {
            PlayerMove.pm.speed = 6;
        }
        else if(isOpen == true)
        {
            PlayerMove.pm.speed = 0;
        }
        else if(QuizManager.QM.isQuizOpen)
        {
            PlayerMove.pm.speed = 0;
        }
       
    }
    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        objectData objData = scanObject.GetComponent<objectData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetBool("isShow", isAction);
    }

    public void Talk(int id, bool isNpc)
    {
        if (id == 2000)
        {
            letterPanel.SetActive(true);
        }

        if(id == 1000)
        {
            birdPanel.SetActive(true);
        }
        
        string talkData = "";

        if (talk.isAnim)
        {
            talk.SetMsg("");
            return;
        }
        else
        {
            talkData = talkManager.GetTalk(id, talkIndex);
        }
        //talk End
        if (talkData == null)
        {
            //npc id가 1000이면 질문창 오픈
            if (id == 1000)
            {
                birdPanel.SetActive(false);
                quizPanel.SetActive(true);
                QuizManager.QM.isQuizOpen = true;
                NPCA.SetActive(false);
            }

            if(id == 2000)
            {
                Ma1Potal.SetActive(true);
                Destroy(NPCB);
                Destroy(letterPanel);
            }

            if(id == 3000)
            {
                quizPanel2.SetActive(true);
                QuizManager.QM.isQuizOpen = true;
                NPCC.SetActive(false);
            }

            if(id == 4000)
            {
                Ma2Potal.SetActive(true);
                BG.SetActive(true);
                Obs2.SetActive(false);
                
            }

            if(id == 5000)
            {
                Map3Potal.SetActive(true);
            }

          
            if(id == 7000)
            {
                StartCoroutine((FadeOut()));
                Dark.SetActive(false);
                PlayerMove.pm.isFadeIn = false;
                NPCA.SetActive(true);
                
            }

            if(id == 8000)
            {
                NPCH.SetActive(true);
            }

            if(id == 9000)
            {
                quizPanel3.SetActive(true);
                NPCH.SetActive(false);
            }
                           
            isAction = false;
            talkIndex = 0;
            return;

        }

        if (isNpc)
        {
            talk.SetMsg(talkData.Split(':')[0]);

            PortraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split(':')[1]));
            PortraitImg.color = new Color(1, 1, 1, 1);

            nameImg.sprite = talkManager.GetName(id, int.Parse(talkData.Split(':')[2]));
            nameImg.color = new Color(1, 1, 1, 1);

            

        }
        else
        {
            talk.SetMsg(talkData);

            PortraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

    public void OpenInGameOption()
    {
        InGameOption.SetActive(true);
        isOpen = true;
    }

    public void CloseInGameOption()
    {
        InGameOption.SetActive(false);
        isOpen = false;
    }

    IEnumerator FadeOut()
    {
        Color alpha = Panel.color;

        //yield return new WaitForSeconds(1f);
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
    }
}

