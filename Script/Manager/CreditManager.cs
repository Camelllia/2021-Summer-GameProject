using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 메인 메뉴 온/오프 스크립트
public class CreditManager : MonoBehaviour
{
    public static CreditManager cm = null;  // ToggleBtn 타입의 인스턴스를 초기화시킨다
    public GameObject cavas;                // 온/오프할 캔버스 GameObject
    public GameObject credit;               // 크레딧 패널로 사용할 GameObject
    public Transform[] Anchor = new Transform[2];                // 크레딧으로 사용할 중심점 Transform
    private byte scrollSpeed = 4;           // 크레딧 스크롤을 위한 변수
    private bool isCredit;                  // 크레딧 활성화 여부를 알기 위한 변수
    public bool scroll;
    
    private void Awake() 
    {
        // 인스턴스가 null 값을 반환할 경우에는 ToggleBtn 타입의 인스턴스를 생성한다
        if (cm == null) cm = this;
    }

    public void Start() 
    {
        // 크레딧을 비활성화시킨다
        credit.SetActive(false);
        isCredit = false;
    }

    public void Update()
    {
        if (isCredit == true)
        {
            // true를 반환하면, 함수를 종료하고, false를 반환하면, 다음 코드로 넘어간다.
            if (!scroll) return;         // 크레딧 스크롤 속도
            Vector3 dir = Vector2.up;   // 크레딧 스크롤 방향

            // 크레딧 앵커는 일정한 속도로 이동한다
            Anchor[0].position += dir * scrollSpeed * Time.deltaTime;
            Anchor[1].position += dir * scrollSpeed * Time.deltaTime;

            SetEndPoint();
        }
    }

    // 크레딧 스크롤에 제한을 주는 메서드
    public void SetEndPoint()
    {
        Vector3 pos1 = Anchor[0].position;
        Vector3 pos2 = Anchor[1].position;

        if (Anchor[0].position.y > 40)
        {
            scroll = false;

            // 크레딧의 스크롤을 중단한다
            pos1.y = 0;
            pos2.y = -20;
            Anchor[0].position = pos1;
            Anchor[1].position = pos2;
        }
    }

    // 크레딧 버튼을 클릭하여 들어간 경우에는
    public void OnClickEnter() 
    {
        // 캔버스를 비활성화시킨다
        cavas.SetActive(false);

        // 크레딧을 활성화시킨다
        credit.SetActive(true);
        isCredit = true;
        scroll = true;
        
    }

    public void OnClick()
    {
        // 크레딧을 활성화시킨다
        credit.SetActive(true);
        isCredit = true;
        scroll = true;
    }

    // 크레딧 버튼을 클릭하여 나간 경우에는
    public void OnClickExit() 
    {
        // 캔버스를 활성화시킨다
        cavas.SetActive(true);

        // 크레딧을 비활성화시킨다
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
