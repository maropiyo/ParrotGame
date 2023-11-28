using UnityEngine;

public class GameModeSelector : MonoBehaviour
{
    public GameObject sceneController;
    public void SelectNormalMode()
    {
        ES3.Save<string>("GameMode", "Normal");
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }

    public void SelectSlipMode()
    {
        ES3.Save<string>("GameMode", "Slip");
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }

    public void SelectJumpMode()
    {
        ES3.Save<string>("GameMode", "Jump");
        sceneController.GetComponent<TitleSceneManager>().LoadGameScene();
    }
}
