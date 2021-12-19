using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransferMap5 : MonoBehaviour
{
    public string transferMapName;
    private PlayerMove pm;
    public GameObject PotalMap1;
    public GameObject PotalMap2;
    public GameObject PotalMap3;
    public GameObject NPCA;
    public GameObject NPCH;
   

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
            PotalMap3.SetActive(false);
            NPCA.SetActive(false);
            NPCH.SetActive(false);
        }
    }

}