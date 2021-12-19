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
        // 로비로 이동한다
        SceneManager.LoadScene(0);
        // 플레이어를 비활성화시킨다
        PlayerMove.pm.player.SetActive(false);
        SaveManager.save.IngameUI.SetActive(false);
    }
}
