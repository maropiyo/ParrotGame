using UnityEngine;
using UnityEngine.UI;

public class ModeSelector : MonoBehaviour
{
    // MainCamera
    public GameObject mainCamera;
    // 太陽の画像
    public Sprite sun;
    // 月の画像
    public Sprite moon;

    void Start()
    {
        // ES3.Loadで変数を読み込む
        EasySaveManager.Instance.LoadGameMode();

        // ゲームモードがSunの場合
        if (EasySaveManager.Instance.GameMode == "Sun")
        {
            // 太陽の画像を表示する
            GetComponent<Image>().sprite = sun;
            // 画像の色をF3C47Bに変更する
            GetComponent<Image>().color = new Color(0.9529412f, 0.7686275f, 0.4823529f);
            // カメラの背景色を昼の色(A8D6E0)に変更する
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.6588235f, 0.8392157f, 0.8784314f);
        }
        // ゲームモードがMoonの場合
        else if (EasySaveManager.Instance.GameMode == "Moon")
        {
            // 月の画像を表示する
            GetComponent<Image>().sprite = moon;
            // 画像の色を(F8EBA3)に変更する
            GetComponent<Image>().color = new Color(0.972549f, 0.9215686f, 0.6392157f);
            // カメラの背景色を夜の色(2A384B)に変更する
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.1647059f, 0.2196078f, 0.2941177f);
        }
    }

    // モードを切り替える
    public void ChangeMode()
    {
        // ゲームモードがSunの場合
        if (EasySaveManager.Instance.GameMode == "Sun")
        {
            // ゲームモードをMoonに変更する
            EasySaveManager.Instance.SaveGameMode("Moon");
            // 月の画像を表示する
            GetComponent<Image>().sprite = moon;
            // 画像の色を(F8EBA3)に変更する
            GetComponent<Image>().color = new Color(0.972549f, 0.9215686f, 0.6392157f);
            // カメラの背景色を夜の色(042741)に変更する
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.01568628f, 0.1529412f, 0.254902f);
        }
        // ゲームモードがMoonの場合
        else if (EasySaveManager.Instance.GameMode == "Moon")
        {
            // ゲームモードをSunに変更する
            EasySaveManager.Instance.SaveGameMode("Sun");
            // 太陽の画像を表示する
            GetComponent<Image>().sprite = sun;
            // 画像の色をF3C47Bに変更する
            GetComponent<Image>().color = new Color(0.9529412f, 0.7686275f, 0.4823529f);
            // カメラの背景色を昼の色(A8D6E0)に変更する
            mainCamera.GetComponent<Camera>().backgroundColor = new Color(0.6588235f, 0.8392157f, 0.8784314f);
        }
    }
}
