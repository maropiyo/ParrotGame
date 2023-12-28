using UnityEngine;
using System.Collections;

public class ObjectPositionChecker : MonoBehaviour
{
    // エリアオブジェクト
    private GameObject area;
    // GameSceneManagerコンポーネント
    private GameSceneManager gameSceneManager;

    void Start()
    {
        area = GameObject.Find("Area");
        // GameSceneManagerオブジェクトのGameSceneManagerコンポーネントを取得
        gameSceneManager = GameObject.Find("GameSceneManager").GetComponent<GameSceneManager>();
    }

    private void FixedUpdate()
    {
        // エリア外に出たかどうかを判定する
        CheckIfOutOfArea();
    }

    // エリア外に出たかどうかを判定する
    private void CheckIfOutOfArea()
    {
        // エリアの左下の座標を取得
        Vector2 areaMin = area.GetComponent<Renderer>().bounds.min;
        // エリアの右上の座標を取得
        Vector2 areaMax = area.GetComponent<Renderer>().bounds.max;
        // オブジェクトの座標を取得
        Vector2 objectPosition = transform.position;

        // エリア外に出たかどうかを判定
        if (enabled && (objectPosition.x < areaMin.x || objectPosition.x > areaMax.x || objectPosition.y < areaMin.y || objectPosition.y > areaMax.y))
        {
            // チェックを無効にする
            enabled = false;

            // ゲームオーバー処理
            gameSceneManager.GameOver();
        }
    }
}
