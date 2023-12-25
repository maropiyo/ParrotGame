using UnityEngine;

[System.Serializable]
public struct SpriteSet
{
    public string type;
    public Sprite normalSprite;
    public Sprite gameoverSprite;
}
public class ParrotSpriteChanger : MonoBehaviour
{
    public SpriteSet[] spriteSetsArray;

    // 現在のタイプのインデックス
    private int currentIndex = 0;

    // タイプに応じたスプライトを設定する
    public void ChangeSprite(string type)
    {
        // タイプに応じたスプライトを設定する
        for (int i = 0; i < spriteSetsArray.Length; i++)
        {
            if (spriteSetsArray[i].type == type)
            {
                GetComponent<SpriteRenderer>().sprite = spriteSetsArray[i].normalSprite;
                currentIndex = i;
                break;
            }
        }
    }

    // 通常時のスプライトに変更する
    public void ChangeNormalSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSetsArray[currentIndex].normalSprite;
    }

    // ゲームオーバー時のスプライトに変更する
    public void ChangeGameOverSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSetsArray[currentIndex].gameoverSprite;
    }
}