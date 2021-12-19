using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

// ���ӸŴ���
public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject OptionWindow;
    public GameObject QuitPanel; //QuitPanel ���� ������Ʈ
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



    #region ���θ޴�

    // ó������ -- PlayerMove�� ��ũ��Ʈ �̵�
    /*public void NewGame()
    {
        SceneManager.LoadScene("Map1");
        PlayerMove.pm.player.SetActive(true);
        PlayerMove.pm.player.transform.position = new Vector3(0, -3, 0);
        SaveManager.save.IngameUI.SetActive(true);

    }
    */

    // �̾��ϱ�
    public void LoadGame()
    {
        LoadManager.load.LoadFromJson();            
    }

    // ũ����
    public void Credit()
    {
        CreditManager.cm.OnClickEnter();
    }

    // ���� ����
    public void exitGame()
    {
        Application.Quit();
        print("Quit");
    }

    #endregion

    #region ȯ�漳��

    // ȯ�漳�� â ����
    public void OpenOption()
    {
        OptionWindow.SetActive(true);
    }

    // ȯ�漳�� â �ݱ�
    public void CloseOption()
    {
        OptionWindow.SetActive(false);
    }

    #endregion


    //QuitPanel ����
    public void OpenQuitPanel()
    {
        QuitPanel.SetActive(true);
    }

    //QuitPanel �ݱ�
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
