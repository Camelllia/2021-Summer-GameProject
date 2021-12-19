using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransferMap2 : MonoBehaviour
{
    public string transferMapName;
    private PlayerMove pm;
    public GameObject PotalMap1;
    public GameObject PotalMap2;
    public GameObject NPCD;
    public GameObject BG;
    public GameObject NPCC;

    void Start()
    {
        pm = FindObjectOfType<PlayerMove>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pm.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
            PotalMap1.SetActive(false);
            PotalMap2.SetActive(false);
            NPCD.SetActive(false);
            BG.SetActive(false);
            NPCC.SetActive(false);
        }
    }

}
