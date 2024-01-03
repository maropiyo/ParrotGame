using UnityEngine;
using UnityEngine.UI;
public class AdjustCamera : MonoBehaviour
{
    public Vector2 _aspectVec2;
    public float _pixelPerUnit;

    void Start()
    {
        Camera _Camera = GetComponent<Camera>();
        float screenW = (float)Screen.width;
        float screenH = (float)Screen.height;

        Debug.Log("screenW:" + screenW);
        Debug.Log("screenH:" + screenH);

        // アスペクト比が16:9より縦長の場合
        if (screenH / screenW <= 16.0f / 9.0f)
        {
            // アスペクト比を16:9にする
            screenW = 1080;
            screenH = 1920;
        }
        // アスペクト比が16:9以上18:9以下の場合
        else if (screenH / screenW <= 18.0f / 9.0f)
        {
            // アスペクト比を18:9にする
            screenW = 1080;
            screenH = 2160;
        }
        else if (screenH / screenW <= 18.5f / 9.0f)// Galaxy S8
        {
            // アスペクト比を18.5:9にする
            screenW = 1080;
            screenH = 2220;
        }
        else if (screenH / screenW <= 19.0f / 9.0f)// Galaxy S9
        {
            // アスペクト比を19:9にする
            screenW = 1080;
            screenH = 2280;
        }
        else if (screenH / screenW <= 19.5f / 9.0f)// iPhone X
        {
            // アスペクト比を19.5:9にする
            screenW = 1080;
            screenH = 2340;
        }
        // アスペクト比が18:9以上20:9以下の場合
        else if (screenH / screenW <= 20.0f / 9.0f)// Xperia 1
        {
            // アスペクト比を20:9にする
            screenW = 1080;
            screenH = 2400;
        }
        else if (screenH / screenW <= 21.0f / 9.0f)// Xperia 1 II
        {
            // アスペクト比を21:9にする
            screenW = 1080;
            screenH = 2520;
        }
        else
        {
            // アスペクト比を22:9にする
            screenW = 1080;
            screenH = 2760;
        }


        _Camera.orthographicSize = screenH / (screenW / (_aspectVec2.x / _pixelPerUnit)) / 2;
    }
}