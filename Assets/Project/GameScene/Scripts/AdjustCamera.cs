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

        // アスペクト比が16:9よりも横長の場合
        if (screenH / screenW < 16.0f / 9.0f)
        {
            // アスペクト比を16:9にする
            screenW = 1080;
            screenH = 1920;
        }


        // アスペクト比が20:9よりも縦長の場合
        if (screenH / screenW > 19.5f / 9.0f)
        {
            // アスペクト比を22:9にする
            screenW = 1080;
            screenH = 3000;
        }


        _Camera.orthographicSize = screenH / (screenW / (_aspectVec2.x / _pixelPerUnit)) / 2;
    }
}