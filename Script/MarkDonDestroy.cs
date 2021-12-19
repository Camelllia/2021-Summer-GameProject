using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDonDestroy : MonoBehaviour
{
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
