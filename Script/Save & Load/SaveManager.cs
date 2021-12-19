using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

// 데이터를 저장하기 위한 함수
public class SaveManager : MonoBehaviour
{
    #region 변수

    public static SaveManager save = null;  // save 인스턴스를 초기화한다
    public GameObject IngameUI;             // 인게임UI의 활성화/비활성화를 위한 변수
    public Vector3 pos;                     // 플레이어의 위치를 저장하기 위한 변수
    public float chapter; // 챕터를 저장하기 위한 변수
    public bool isNewGame;  //첫번째 게임인지 확인하기 위한 변수

    public Scene scene;                     // 씬 번호를 알기 위한 변수
    public int sceneIndex;                  // 씬 번호를 저장하기 위한 변수

    #endregion

    #region 콜백

    public void Awake()
    {

        // 인스턴스가 null값인 경우에는 인스턴스를 생성한다
        if (save == null) save = this;
        //게임을 시작하면 저장한 적 없는 첫 게임이다
        isNewGame = true;
    }

    public void Update()
    {
        // 씬 번호를 가져온다
        Scene();
        // 플레이어의 위치를 가져온다
        pos = PlayerMove.pm.transform.position;
    }

    #endregion

    #region 함수

    // 씬 번호를 가져오기 위한 메서드
    public void Scene()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
    }

    // 저장하기
    public void SaveToJson()
    {
        // SaveData 클래스의 객체 data를 생성한다
        SaveData data = new SaveData
        {
            // Data는 객체의 문자열의 반환값을 할당한다
            sceneData = sceneIndex,
            chapterData = chapter,
            posXData = pos.x,
            posYData = pos.y,
            posZData = pos.z,
        };

        // data를 JSON 포맷인 json으로 직렬화한다
        string json = JsonUtility.ToJson(data, true);
        // json을 특정 경로에 있는 Text에 입력한다
        File.WriteAllText(Application.dataPath + "/SaveData.json", json);

        //저장하기 버튼을 눌렀다면 첫번째 게임이 아니게 된다 즉, 이어하기 기능을 사용할 수 있음
        isNewGame = false;
    }

    // 로비로 이동
    public void OnClickExit()
    {
        // 로비로 이동한다
        SceneManager.LoadScene(0);
        // 플레이어를 비활성화시킨다
        PlayerMove.pm.player.SetActive(false);
        SaveManager.save.IngameUI.SetActive(false);
    }

    public void RestToJson()
    {
        //SaveData 클래스의 객체 data를 생성한다
        SaveData data = new SaveData
        {
            //Data는 객체의 문자열의 반환값을 할당한다
            sceneData = 1,
            chapterData = 1,
            posXData = 0,
            posYData = -3,
            posZData = 0
        };

        //data를 JSON 포맷인 json으로 직렬화한다
        string json = JsonUtility.ToJson(data, true);
        //json을 특정 경로에 있는 Text에 입력한다
        File.WriteAllText(Application.dataPath + "/SaveData.json",json.ToString());
    }
    

}

    

    #endregion
    