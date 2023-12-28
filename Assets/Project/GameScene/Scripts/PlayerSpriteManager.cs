using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManager : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite fallSprite;
    private SpriteRenderer playerSpriteRenderer;


    private void Start()
    {
        // SpriteRendererコンポーネントを取得
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // 通常時のスプライトに変更する
    public void ChangeNormalSprite(GameObject spawnedObject)
    {
        if (playerSpriteRenderer)
        {
            playerSpriteRenderer.sprite = normalSprite;
        }
    }

    // 落下時のスプライトに変更する
    public void ChangeFallSprite()
    {
        if (playerSpriteRenderer)
        {
            playerSpriteRenderer.sprite = fallSprite;
        }
    }
}
