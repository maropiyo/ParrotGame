using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIModeChanger : MonoBehaviour
{
    // カメラ
    public GameObject mainCamera;

    void Start()
    {
        // モードに合わせてUIを変更する
        ChangeMode();
    }

    // モードに合わせてUIを変更する
    private void ChangeMode()
    {
        // ゲームモードがSunの場合
        if (EasySaveManager.Instance.GameMode == "Sun")
        {
            // カメラの背景色を昼の色(A8D6E0)に変更する
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.6588235f, 0.8392157f, 0.8784314f);
        }
        // ゲームモードがMoonの場合
        else if (EasySaveManager.Instance.GameMode == "Moon")
        {
            // カメラの背景色を夜の色(2A384B)に変更する
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.1647059f, 0.2196078f, 0.2941177f);
        }
    }
}
