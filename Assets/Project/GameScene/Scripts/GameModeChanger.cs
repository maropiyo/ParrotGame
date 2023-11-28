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
        gameModeChange(gameMode);
    }

    private void gameModeChange(string gameMode)
    {
        switch (gameMode)
        {
            case "Normal":
                parrotPhysicsMaterial.friction = 0.3f;
                parrotPhysicsMaterial.bounciness = 0;
                break;
            case "Slip":
                parrotPhysicsMaterial.friction = 0;
                parrotPhysicsMaterial.bounciness = 0;
                break;
            case "Jump":
                parrotPhysicsMaterial.friction = 0.1f;
                parrotPhysicsMaterial.bounciness = 1.0f;
                break;
            default:
                break;
        }
    }
}
