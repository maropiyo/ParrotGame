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
                parrotPhysicsMaterial.friction = 0.3f;
                parrotPhysicsMaterial.bounciness = 0;
                break;
            case "Jump":
                parrotPhysicsMaterial.friction = 0.3f;
                parrotPhysicsMaterial.bounciness = 0.9f;
                break;
            case "SuperJump":
                parrotPhysicsMaterial.friction = 0.1f;
                parrotPhysicsMaterial.bounciness = 1f;
                break;
            default:
                break;
        }
    }
}
