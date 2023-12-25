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
        gameMode = ES3.Load<string>("GameMode");
        GameModeChange(gameMode);
    }

    private void GameModeChange(string gameMode)
    {
        switch (gameMode)
        {
            case "Normal":
                parrotPhysicsMaterial.friction = 0.2f;
                parrotPhysicsMaterial.bounciness = 0f;
                break;
            case "Hard":
                parrotPhysicsMaterial.friction = 0.2f;
                parrotPhysicsMaterial.bounciness = 0.8f;
                break;
            default:
                break;
        }
    }
}
