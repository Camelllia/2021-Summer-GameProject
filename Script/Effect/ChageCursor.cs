using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageCursor : MonoBehaviour
{
    //마우스 커서 변경 스크립트

    [SerializeField] Texture2D cursurImg;

    void Start()
    {
        Cursor.SetCursor(cursurImg, Vector2.zero, CursorMode.ForceSoftware);
    }

   
}
