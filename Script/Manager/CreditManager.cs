using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �޴� ��/���� ��ũ��Ʈ
public class CreditManager : MonoBehaviour
{
    public static CreditManager cm = null;  // ToggleBtn Ÿ���� �ν��Ͻ��� �ʱ�ȭ��Ų��
    public GameObject cavas;                // ��/������ ĵ���� GameObject
    public GameObject credit;               // ũ���� �гη� ����� GameObject
    public Transform[] Anchor = new Transform[2];                // ũ�������� ����� �߽��� Transform
    private byte scrollSpeed = 4;           // ũ���� ��ũ���� ���� ����
    private bool isCredit;                  // ũ���� Ȱ��ȭ ���θ� �˱� ���� ����
    public bool scroll;
    
    private void Awake() 
    {
        // �ν��Ͻ��� null ���� ��ȯ�� ��쿡�� ToggleBtn Ÿ���� �ν��Ͻ��� �����Ѵ�
        if (cm == null) cm = this;
    }

    public void Start() 
    {
        // ũ������ ��Ȱ��ȭ��Ų��
        credit.SetActive(false);
        isCredit = false;
    }

    public void Update()
    {
        if (isCredit == true)
        {
            // true�� ��ȯ�ϸ�, �Լ��� �����ϰ�, false�� ��ȯ�ϸ�, ���� �ڵ�� �Ѿ��.
            if (!scroll) return;         // ũ���� ��ũ�� �ӵ�
            Vector3 dir = Vector2.up;   // ũ���� ��ũ�� ����

            // ũ���� ��Ŀ�� ������ �ӵ��� �̵��Ѵ�
            Anchor[0].position += dir * scrollSpeed * Time.deltaTime;
            Anchor[1].position += dir * scrollSpeed * Time.deltaTime;

            SetEndPoint();
        }
    }

    // ũ���� ��ũ�ѿ� ������ �ִ� �޼���
    public void SetEndPoint()
    {
        Vector3 pos1 = Anchor[0].position;
        Vector3 pos2 = Anchor[1].position;

        if (Anchor[0].position.y > 40)
        {
            scroll = false;

            // ũ������ ��ũ���� �ߴ��Ѵ�
            pos1.y = 0;
            pos2.y = -20;
            Anchor[0].position = pos1;
            Anchor[1].position = pos2;
        }
    }

    // ũ���� ��ư�� Ŭ���Ͽ� �� ��쿡��
    public void OnClickEnter() 
    {
        // ĵ������ ��Ȱ��ȭ��Ų��
        cavas.SetActive(false);

        // ũ������ Ȱ��ȭ��Ų��
        credit.SetActive(true);
        isCredit = true;
        scroll = true;
        
    }

    public void OnClick()
    {
        // ũ������ Ȱ��ȭ��Ų��
        credit.SetActive(true);
        isCredit = true;
        scroll = true;
    }

    // ũ���� ��ư�� Ŭ���Ͽ� ���� ��쿡��
    public void OnClickExit() 
    {
        // ĵ������ Ȱ��ȭ��Ų��
        cavas.SetActive(true);

        // ũ������ ��Ȱ��ȭ��Ų��
        credit.SetActive(false);
        isCredit = false;

        Vector3 pos1 = Anchor[0].position;
        Vector3 pos2 = Anchor[1].position;

        pos1.y = 0;
        pos2.y = -20;
        Anchor[0].position = pos1;
        Anchor[1].position = pos2;
    }

}
