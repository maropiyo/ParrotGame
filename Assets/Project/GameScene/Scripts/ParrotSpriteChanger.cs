using UnityEngine;

[System.Serializable]
public struct SpriteSet
{
    public string colorType;
    public Sprite normalSprite;
    public Sprite gameoverSprite;
}
public class ParrotSpriteChanger : MonoBehaviour
{
    public SpriteSet[] spriteSetsArray;

    // 現在のカラーのインデックス
    private int currentColorTypeIndex = 0;

    // カラーに応じたスプライトを設定する
    public void ChangeSprite(string color)
    {
        // タイプに応じたスプライトを設定する
        for (int i = 0; i < spriteSetsArray.Length; i++)
        {
            if (spriteSetsArray[i].colorType == color)
            {
                GetComponent<SpriteRenderer>().sprite = spriteSetsArray[i].normalSprite;
                currentColorTypeIndex = i;
                break;
            }
        }
    }

    // 通常時のスプライトに変更する
    public void ChangeNormalSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSetsArray[currentColorTypeIndex].normalSprite;
    }

    // ゲームオーバー時のスプライトに変更する
    public void ChangeGameOverSprite()
    {
        GetComponent<SpriteRenderer>().sprite = spriteSetsArray[currentColorTypeIndex].gameoverSprite;
    }
}