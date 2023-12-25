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
}