using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
    public static bool isCursorVisible = false;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        /**
        if (Input.GetKey(KeyCode.E))
        {
            isCursorVisible = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            isCursorVisible = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        -*/
        }
    public void HideAndCenterCursor(bool hide)
    {
        if (hide)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;  
        }
        else if (!hide)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;   
        }
    }
}
