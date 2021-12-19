using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove pm = null;
    public float speed;
    public Scene1Manager manager;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    public GameObject player;
    GameObject scanObject;
    Rigidbody2D rigid;
    public Text InterationText;
    public string currentMapName;
    public SpriteRenderer SR;
    public string sceneName;
    public GameObject NpcMark1000;
    public string ObjName;
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    public bool isFadeIn;
    public GameObject Cam;
    public QuizManager QM;
    public MapManager MM;
    public Animator Anim;
    

    void Awake()
    {
        if (pm == null)  
        {
            pm = this;
        }

        SR = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        InterationText.text = "";
        SR.color = new Color(1, 1, 1, 0);

    }
    
    void Update()
    {
        // 클론 제거에 관한 메서드
        DestroyClone();

        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");
       
        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;



        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
        {
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1)
        {
            dirVec = Vector3.right;
        }

        if (Input.GetButtonDown("Jump") && scanObject != null)
        {
            Debug.Log(scanObject.name);
            ObjName = scanObject.name;
            manager.Action(scanObject);
        }
        else if (scanObject != null)
        {
            InterationText.text = "대화:SPACEBAR";
        }
        

        if(Input.GetButton("Horizontal") && !manager.isAction && !manager.isOpen && !QuizManager.QM.isQuizOpen && !isFadeIn && !MM.isMapOpen)
        {
            SR.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if (isFadeIn)
            speed = 0;
        else if (!isFadeIn && !manager.isOpen && !QuizManager.QM.isQuizOpen)
            speed = 6;

        this.transform.position = new Vector3(transform.position.x, -2.7f, transform.position.z);

        //Animation
        Anim.SetInteger("hAxisRaw", (int)h);
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 1f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        InterationText.text = "";
    }

    // 클론 제거에 관한 메서드
    void DestroyClone()
    {
        // PlayerMove 컴포넌트를 가진 객체 obj를 찾는다
        var obj = FindObjectsOfType<PlayerMove>();

        // obj의 개수가 한개일 경우에는
        if (obj.Length == 1)
        {
            // 플레이어를 파괴하지 않는다
            DontDestroyOnLoad(player);
        }
        // obj의 개수가 한개 이상일 경우에는 버그이므로 
        else
        {
            // 클론을 제거하여 플레이어를 한개로 유지한다
            Destroy(player);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Map1");
        StartCoroutine(FadeIn());
        PlayerMove.pm.player.SetActive(true);
        PlayerMove.pm.player.transform.position = new Vector3(12.32f, -2.8f, 0);
        SaveManager.save.IngameUI.SetActive(true);
        SR.color = new Color(1, 1, 1, 1);
        NpcMark1000.SetActive(true);
        isFadeIn = true;
    }


    IEnumerator FadeIn()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
    }

}