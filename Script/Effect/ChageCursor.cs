using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageCursor : MonoBehaviour
{
    //���콺 Ŀ�� ���� ��ũ��Ʈ

    [SerializeField] Texture2D cursurImg;

    void Start()
    {
        Cursor.SetCursor(cursurImg, Vector2.zero, CursorMode.ForceSoftware);
    }

   
}
