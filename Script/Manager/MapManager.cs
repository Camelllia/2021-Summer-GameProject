using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameObject mapOption;
    public bool isMapOpen;

    private void Awake()
    {
        isMapOpen = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && isMapOpen == false)
        {
            mapOption.SetActive(true);
            isMapOpen = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.M) && isMapOpen == true)
        {
            mapOption.SetActive(false);
            isMapOpen = false;
        }

        if(isMapOpen == true)
        {
            Time.timeScale = 0f;
        }
        else if(isMapOpen == false)
        {
            Time.timeScale = 1f;
        }
    }

    public void openWindow()
    {
        mapOption.SetActive(true);
    }

    public void closeWindow()
    {
        mapOption.SetActive(false);
    }



}
