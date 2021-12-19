using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkDontDestroy : MonoBehaviour
{
    
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if(SceneManager.GetActiveScene().name == "Map1")
        {
            this.transform.position = new Vector3(12.32f, -3, 0);
        }
    }
}
