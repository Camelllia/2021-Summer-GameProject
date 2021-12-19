using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

// 게임매니저
public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject OptionWindow;
    public GameObject QuitPanel; //QuitPanel 게임 오브젝트
    public GameObject NPCB;
    public GameObject Map1Potal;
    public GameObject Map2Potal;
    public GameObject Map3Potal;
    public GameObject Map4Potal;
    public GameObject NPCD;
    public GameObject NpcMark1000;
    public GameObject Obstacle;
    public GameObject NPCH;
    public GameObject NPCA;
    public GameObject BG;
    public GameObject OBs2;
    public GameObject NPCC;
    

    public void Awake()
    {
        gm = this;
        StartCoroutine(Delay());
    }



    #region 메인메뉴

    // 처음부터 -- PlayerMove로 스크립트 이동
    /*public void NewGame()
    {
        SceneManager.LoadScene("Map1");
        PlayerMove.pm.player.SetActive(true);
        PlayerMove.pm.player.transform.position = new Vector3(0, -3, 0);
        SaveManager.save.IngameUI.SetActive(true);

    }
    */

    // 이어하기
    public void LoadGame()
    {
        LoadManager.load.LoadFromJson();            
    }

    // 크레딧
    public void Credit()
    {
        CreditManager.cm.OnClickEnter();
    }

    // 게임 종료
    public void exitGame()
    {
        Application.Quit();
        print("Quit");
    }

    #endregion

    #region 환경설정

    // 환경설정 창 열기
    public void OpenOption()
    {
        OptionWindow.SetActive(true);
    }

    // 환경설정 창 닫기
    public void CloseOption()
    {
        OptionWindow.SetActive(false);
    }

    #endregion


    //QuitPanel 열기
    public void OpenQuitPanel()
    {
        QuitPanel.SetActive(true);
    }

    //QuitPanel 닫기
    public void CloseQuitPanel()
    {
        QuitPanel.SetActive(false);
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.01f);

        NPCB.SetActive(false);
        Map1Potal.SetActive(false);
        Map2Potal.SetActive(false);
        Map2Potal.SetActive(false);
        NPCD.SetActive(false);
        Map3Potal.SetActive(false);
        Map4Potal.SetActive(false);
        Obstacle.SetActive(false);
        NPCH.SetActive(false);
        NPCA.SetActive(false);
        BG.SetActive(false);
        OBs2.SetActive(false);
        NPCC.SetActive(false);
    }
}
