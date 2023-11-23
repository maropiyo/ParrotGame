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
                parrotPhysicsMaterial.friction = 0.4f;
                parrotPhysicsMaterial.bounciness = 0;
                break;
            case "Jump":
                parrotPhysicsMaterial.friction = 0.4f;
                parrotPhysicsMaterial.bounciness = 0.9f;
                break;
            case "Slip":
                parrotPhysicsMaterial.friction = 0;
                parrotPhysicsMaterial.bounciness = 0;
                break;
            case "SlipAndJump":
                parrotPhysicsMaterial.friction = 0;
                parrotPhysicsMaterial.bounciness = 0.9f;
                break;
            default:
                break;
        }
    }
}
