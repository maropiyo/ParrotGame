using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeLoader : MonoBehaviour
{
    // インコのマテリアル
    public PhysicsMaterial2D parrotPhysicsMaterial;
    // ゲームモード
    private string gameMode;

    void Start()
    {
        EasySaveManager.Instance.LoadGameMode();
        gameMode = EasySaveManager.Instance.GameMode;
        GameModeChange(gameMode);
    }

    private void GameModeChange(string gameMode)
    {
        switch (gameMode)
        {
            case "Sun":
                parrotPhysicsMaterial.friction = 0.2f;
                parrotPhysicsMaterial.bounciness = 0f;
                break;
            case "Moon":
                parrotPhysicsMaterial.friction = 0.2f;
                parrotPhysicsMaterial.bounciness = 1.0f;
                break;
            default:
                break;
        }
    }
}
