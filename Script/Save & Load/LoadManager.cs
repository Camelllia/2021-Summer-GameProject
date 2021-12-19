using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    #region 변수

    public static LoadManager load = null;  // save 인스턴스를 초기화한다
    public Scene scene;                     // 씬 번호를 알기 위한 변수
    public int sceneIndex;                  // 씬 번호를 저장하기 위한 변수
    public float chapter;                   // 챕터를 저장하기 위한 변수
    public Vector3 pos; // 플레이어의 위치를 저장하기 위한 변수
    public GameObject NoSavaDataPanel; //세이브 데이터가 없다는 것을 표시하기 위한 게임오브젝트(패널)
    public GameObject Player;
    public SpriteRenderer SR;

    #endregion

    #region 콜백

    public void Awake()
    {
        // 인스턴스가 null값인 경우에는 인스턴스를 생성한다
        if (load == null) load = this;
        SR = Player.GetComponentInChildren<SpriteRenderer>();
    }

    #endregion

    #region 함수

    // 불러오기
    public void LoadFromJson()
    {
        
        
            // json은 특정 경로에 있는 Text를 읽어온다
            string json = File.ReadAllText(Application.dataPath + "/SaveData.json");
            // JSON 포맷인 json을 data로 역직렬화한다
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            sceneIndex = data.sceneData;
            chapter = data.chapterData;
            pos = new Vector3(data.posXData, data.posYData, data.posZData);

            // 저장된 씬을 로드한다
            SceneManager.LoadScene(sceneIndex);
            // 저장된 위치로 플레이어를 이동시킨다
            PlayerMove.pm.player.transform.position = pos;
            // 플레이어를 활성화시킨다
            PlayerMove.pm.player.SetActive(true);
            SaveManager.save.IngameUI.SetActive(true);
            SR.color = new Color(1, 1, 1, 1); 
        
    }

    //패널을 실행시키기 위한 코루틴
    IEnumerator NoSaveData()
    {
        NoSavaDataPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        NoSavaDataPanel.SetActive(false);
    }

    #endregion
}