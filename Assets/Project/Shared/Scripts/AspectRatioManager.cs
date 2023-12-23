using UnityEngine;
using UnityEngine.SceneManagement;

public class AspectRatioManager : MonoBehaviour
{
    // シングルトンパターンの実装
    private static AspectRatioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // 目標のアスペクト比X
    public float targetAspectX = 9.0f;
    // 目標のアスペクト比Y
    public float targetAspectY = 19.5f;
    // 目標のアスペクト比
    private float targetAspect;

    void Start()
    {
        // 画面サイズからアスペクト比を計算する
        targetAspect = (float)Screen.width / (float)Screen.height;

        // 目標のアスペクト比を計算する
        // targetAspect = targetAspectX / targetAspectY;

        // シーンがロードされた時に呼び出されるイベントにメソッドを登録する
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // シーンがロードされた時に呼び出される
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // アスペクト比を調整する
        AdjustAspectRatio();
    }

    void Update()
    {
        // 画面サイズが変更された場合にもアスペクト比を調整する
        if (Screen.width != lastScreenWidth || Screen.height != lastScreenHeight)
        {
            AdjustAspectRatio();
        }
    }

    private float lastScreenWidth;
    private float lastScreenHeight;

    void AdjustAspectRatio()
    {
        lastScreenWidth = Screen.width;
        lastScreenHeight = Screen.height;

        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = Camera.main;

        if (scaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}
