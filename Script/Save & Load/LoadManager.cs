using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    #region ����

    public static LoadManager load = null;  // save �ν��Ͻ��� �ʱ�ȭ�Ѵ�
    public Scene scene;                     // �� ��ȣ�� �˱� ���� ����
    public int sceneIndex;                  // �� ��ȣ�� �����ϱ� ���� ����
    public float chapter;                   // é�͸� �����ϱ� ���� ����
    public Vector3 pos; // �÷��̾��� ��ġ�� �����ϱ� ���� ����
    public GameObject NoSavaDataPanel; //���̺� �����Ͱ� ���ٴ� ���� ǥ���ϱ� ���� ���ӿ�����Ʈ(�г�)
    public GameObject Player;
    public SpriteRenderer SR;

    #endregion

    #region �ݹ�

    public void Awake()
    {
        // �ν��Ͻ��� null���� ��쿡�� �ν��Ͻ��� �����Ѵ�
        if (load == null) load = this;
        SR = Player.GetComponentInChildren<SpriteRenderer>();
    }

    #endregion

    #region �Լ�

    // �ҷ�����
    public void LoadFromJson()
    {
        
        
            // json�� Ư�� ��ο� �ִ� Text�� �о�´�
            string json = File.ReadAllText(Application.dataPath + "/SaveData.json");
            // JSON ������ json�� data�� ������ȭ�Ѵ�
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            sceneIndex = data.sceneData;
            chapter = data.chapterData;
            pos = new Vector3(data.posXData, data.posYData, data.posZData);

            // ����� ���� �ε��Ѵ�
            SceneManager.LoadScene(sceneIndex);
            // ����� ��ġ�� �÷��̾ �̵���Ų��
            PlayerMove.pm.player.transform.position = pos;
            // �÷��̾ Ȱ��ȭ��Ų��
            PlayerMove.pm.player.SetActive(true);
            SaveManager.save.IngameUI.SetActive(true);
            SR.color = new Color(1, 1, 1, 1); 
        
    }

    //�г��� �����Ű�� ���� �ڷ�ƾ
    IEnumerator NoSaveData()
    {
        NoSavaDataPanel.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        NoSavaDataPanel.SetActive(false);
    }

    #endregion
}