using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamFix : MonoBehaviour
{
    public AudioSource AS;

    public Transform target;
    Vector3 originPos;
    public GameObject cam;
    public float speed;

    public Vector2 center1;
    public Vector2 size1;
    float height1;
    float width1;

    public Vector2 center2;
    public Vector2 size2;
    float height2;
    float width2;

    public Vector2 center3;
    public Vector2 size3;
    float height3;
    float width3;

    public Vector2 center4;
    public Vector2 size4;
    float height4;
    float width4;

    public Vector2 center5;
    public Vector2 size5;
    float height5;
    float width5;

    public bool isAnim = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // 클론 제거에 관한 메서드
        DestroyClone();
    }

    void Start()
    {
        height1 = Camera.main.orthographicSize;
        width1 = height1 * Screen.width / Screen.height;

        height2 = Camera.main.orthographicSize;
        width2 = height2 * Screen.width / Screen.height;

        height3 = Camera.main.orthographicSize;
        width3 = height3 * Screen.width / Screen.height;

        height4 = Camera.main.orthographicSize;
        width4 = height4 * Screen.width / Screen.height;

        height5 = Camera.main.orthographicSize;
        width5 = height1 * Screen.width / Screen.height;

        originPos = transform.localPosition;
    }

    void Update()
    {
        // 로비인 경우에는
        if (SceneManager.GetActiveScene().buildIndex == 0)
            // 카메라를 원위치로 이동시킨다
            cam.transform.position = new Vector3(0.15f, 0, -56.8f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center1, size1);

        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(center2, size2);

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(center3, size3);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center4, size4);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(center5, size5);
    }

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Map1")
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, 0f, -10f);

            float lx = size1.x * 0.5f - width1;
            float clampX = Mathf.Clamp(transform.position.x, -lx + center1.x, lx + center1.x);

            float ly = size1.y * 0.5f - height1;
            float clampY = Mathf.Clamp(transform.position.y, -ly + center1.x, ly + center1.x);

            transform.position = new Vector3(clampX, clampY, -10f);
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, 0f, -10f);

            float lx2 = size2.x * 0.5f - width2;
            float clampX2 = Mathf.Clamp(transform.position.x, -lx2 + center2.x, lx2 + center2.x);

            float ly2 = size2.y * 0.5f - height2;
            float clampY2 = Mathf.Clamp(transform.position.y, -ly2 + center2.x, ly2 + center2.x);

            transform.position = new Vector3(clampX2, clampY2, -10f);
        }
        else if (SceneManager.GetActiveScene().name == "Map3")
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, 0f, -10f);

            float lx3 = size3.x * 0.5f - width3;
            float clampX3 = Mathf.Clamp(transform.position.x, -lx3 + center3.x, lx3 + center3.x);

            float ly3 = size3.y * 0.5f - height3;
            float clampY3 = Mathf.Clamp(transform.position.y, -ly3 + center3.x, ly3 + center3.x);

            transform.position = new Vector3(clampX3, clampY3, -10f);
        }
        else if (SceneManager.GetActiveScene().name == "Map4")
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
            transform.position = new Vector3(transform.position.x, 0f, -10f);

            float lx4 = size4.x * 0.5f - width4;
            float clampX4 = Mathf.Clamp(transform.position.x, -lx4 + center4.x, lx4 + center4.x);

            float ly4 = size4.y * 0.5f - height4;
            float clampY4 = Mathf.Clamp(transform.position.y, -ly4 + center4.x, ly4 + center4.x);

            transform.position = new Vector3(clampX4, clampY4, -10f);
        }
        else if (SceneManager.GetActiveScene().name == "Map5")
        {

            if (isAnim)
            {
                AS.Play();

                //Vector3 startPos = new Vector3(-13.9f, 0.0f, -10.0f);
                Vector3 finishPos = new Vector3(19.6f, 0.0f, -10.0f);
                Vector3 needPos = new Vector3(19.5f, 0.0f, -10.0f);
                originPos = needPos;
                transform.position = Vector3.Lerp(transform.position, finishPos, Time.deltaTime * 1f);
                transform.position = new Vector3(transform.position.x, 0f, -10f);


                if (transform.position.x >= needPos.x)
                {
                    StartCoroutine(Shake(3, 3));
                }

                
            }
            else if (!isAnim)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
                transform.position = new Vector3(transform.position.x, 0f, -10f);

                float lx5 = size5.x * 0.5f - width5;
                float clampX5 = Mathf.Clamp(transform.position.x, -lx5 + center5.x, lx5 + center5.x);

                float ly5 = size5.y * 0.5f - height5;
                float clampY5 = Mathf.Clamp(transform.position.y, -ly5 + center5.x, ly5 + center5.x);

                transform.position = new Vector3(clampX5, clampY5, -10f);

                AS.Stop();
            }
        }
    }

    // 클론 제거에 관한 메서드
    void DestroyClone()
    {
        // CamFix 컴포넌트를 가진 객체 obj를 찾는다
        var obj = FindObjectsOfType<CamFix>();

        // obj의 개수가 한개일 경우에는
        if (obj.Length == 1)
        {
            // 카메라를 파괴하지 않는다
            DontDestroyOnLoad(cam);
        }
        // obj의 개수가 한개 이상일 경우에는 버그이므로 
        else
        {
            // 클론을 제거하여 카메라를 한개로 유지한다
            Destroy(cam);
        }
    }

    // 카메라 흔들림
    public IEnumerator Shake(float _amount, float _duration)
    {
        float timer = 0;
        while (timer <= _duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitCircle * _amount + originPos;

            timer += Time.deltaTime;
            yield return null;
        }
        isAnim = false;
        transform.localPosition = originPos;
    }
}