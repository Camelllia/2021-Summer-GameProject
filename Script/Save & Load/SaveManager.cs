using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

// �����͸� �����ϱ� ���� �Լ�
public class SaveManager : MonoBehaviour
{
    #region ����

    public static SaveManager save = null;  // save �ν��Ͻ��� �ʱ�ȭ�Ѵ�
    public GameObject IngameUI;             // �ΰ���UI�� Ȱ��ȭ/��Ȱ��ȭ�� ���� ����
    public Vector3 pos;                     // �÷��̾��� ��ġ�� �����ϱ� ���� ����
    public float chapter; // é�͸� �����ϱ� ���� ����
    public bool isNewGame;  //ù��° �������� Ȯ���ϱ� ���� ����

    public Scene scene;                     // �� ��ȣ�� �˱� ���� ����
    public int sceneIndex;                  // �� ��ȣ�� �����ϱ� ���� ����

    #endregion

    #region �ݹ�

    public void Awake()
    {

        // �ν��Ͻ��� null���� ��쿡�� �ν��Ͻ��� �����Ѵ�
        if (save == null) save = this;
        //������ �����ϸ� ������ �� ���� ù �����̴�
        isNewGame = true;
    }

    public void Update()
    {
        // �� ��ȣ�� �����´�
        Scene();
        // �÷��̾��� ��ġ�� �����´�
        pos = PlayerMove.pm.transform.position;
    }

    #endregion

    #region �Լ�

    // �� ��ȣ�� �������� ���� �޼���
    public void Scene()
    {
        scene = SceneManager.GetActiveScene();
        sceneIndex = scene.buildIndex;
    }

    // �����ϱ�
    public void SaveToJson()
    {
        // SaveData Ŭ������ ��ü data�� �����Ѵ�
        SaveData data = new SaveData
        {
            // Data�� ��ü�� ���ڿ��� ��ȯ���� �Ҵ��Ѵ�
            sceneData = sceneIndex,
            chapterData = chapter,
            posXData = pos.x,
            posYData = pos.y,
            posZData = pos.z,
        };

        // data�� JSON ������ json���� ����ȭ�Ѵ�
        string json = JsonUtility.ToJson(data, true);
        // json�� Ư�� ��ο� �ִ� Text�� �Է��Ѵ�
        File.WriteAllText(Application.dataPath + "/SaveData.json", json);

        //�����ϱ� ��ư�� �����ٸ� ù��° ������ �ƴϰ� �ȴ� ��, �̾��ϱ� ����� ����� �� ����
        isNewGame = false;
    }

    // �κ�� �̵�
    public void OnClickExit()
    {
        // �κ�� �̵��Ѵ�
        SceneManager.LoadScene(0);
        // �÷��̾ ��Ȱ��ȭ��Ų��
        PlayerMove.pm.player.SetActive(false);
        SaveManager.save.IngameUI.SetActive(false);
    }

    public void RestToJson()
    {
        //SaveData Ŭ������ ��ü data�� �����Ѵ�
        SaveData data = new SaveData
        {
            //Data�� ��ü�� ���ڿ��� ��ȯ���� �Ҵ��Ѵ�
            sceneData = 1,
            chapterData = 1,
            posXData = 0,
            posYData = -3,
            posZData = 0
        };

        //data�� JSON ������ json���� ����ȭ�Ѵ�
        string json = JsonUtility.ToJson(data, true);
        //json�� Ư�� ��ο� �ִ� Text�� �Է��Ѵ�
        File.WriteAllText(Application.dataPath + "/SaveData.json",json.ToString());
    }
    

}

    

    #endregion
    