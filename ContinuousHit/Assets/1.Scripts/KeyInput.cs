using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자의 입력값을 받아오는 녀석입니다
public class KeyInput : MonoBehaviour
{
    public static KeyInput Instance;

    private void Awake() {
        Instance = this;
    }

    public bool KeyLeft() {
        return Input.GetKeyDown(KeyCode.LeftControl);
    }

    public bool KeyRight() {
        return Input.GetKeyDown(KeyCode.RightControl);
    }
}
