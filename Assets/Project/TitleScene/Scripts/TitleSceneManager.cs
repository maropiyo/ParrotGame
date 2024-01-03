using PlayFab;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    // GameSceneに遷移する。
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    // ParrotSelectSceneに遷移する。
    public void LoadParrotSelectScene()
    {
        SceneManager.LoadScene("ParrotSelectScene");
    }
}
