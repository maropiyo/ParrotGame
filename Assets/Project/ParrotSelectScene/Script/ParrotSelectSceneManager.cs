using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParrotSelectSceneManager : MonoBehaviour
{
    /// タイトルシーンに遷移する。
    public void LoadTitleScene()
    {
        // タイトルシーンに遷移する。
        SceneManager.LoadScene("TitleScene");
    }
}
