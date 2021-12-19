using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Dal;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Panel.SetActive(true);
        Dal.SetActive(false);
    }

    public void Exit()
    {
        // �κ�� �̵��Ѵ�
        SceneManager.LoadScene(0);
        // �÷��̾ ��Ȱ��ȭ��Ų��
        PlayerMove.pm.player.SetActive(false);
        SaveManager.save.IngameUI.SetActive(false);
    }
}
