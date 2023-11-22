using UnityEngine;

public class ObjectPositionChecker : MonoBehaviour
{
    private void Update()
    {
        CheckIfOutOfScreen();
    }

    private void CheckIfOutOfScreen()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // 画面外に出たかどうかを判定
        if (screenPosition.x < 0 || Screen.width < screenPosition.x || screenPosition.y < 0)
        {
            // GameSceneManagerを取得
            GameSceneManager gameSceneManager = GameObject.FindWithTag("SceneManager").GetComponent<GameSceneManager>();

            if (gameSceneManager)
            {
                gameSceneManager.LoadTitleScene();
            }
        }
    }
}
