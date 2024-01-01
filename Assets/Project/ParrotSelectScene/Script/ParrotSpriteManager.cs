using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParrotSpriteManager : MonoBehaviour
{
    // インコのプレハブリスト
    public GameObject[] parrotPrefabList;

    // 選択中のインコの画像
    public Image SelectedParrotImage;
    // 選択中のインコの名前
    public Text SelectedParrotNameText;
    // 選択中のインコの説明
    public Text SelectedParrotDescriptionText;


    /**
     * UI
     */
    public Image MamerurihaImage;
    public Image BotanImage;
    public Image SazanamiImage;
    public Image KozakuraImage;
    public Image SekiseiImage;
    public Image AkikusaImage;
    public Image ShiroharaImage;
    public Image OkameImage;
    public Image MomoiroImage;
    public Image OhanaImage;
    public Image KongoImage;

    void Start()
    {
        // インコの情報をセットする
        SetParrotInfo();
    }

    // インコの情報をセットする
    private void SetParrotInfo()
    {
        // UIのインコの画像をセット
        MamerurihaImage.sprite = parrotPrefabList[0].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        BotanImage.sprite = parrotPrefabList[1].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        SazanamiImage.sprite = parrotPrefabList[2].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        KozakuraImage.sprite = parrotPrefabList[3].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        SekiseiImage.sprite = parrotPrefabList[4].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        AkikusaImage.sprite = parrotPrefabList[5].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        ShiroharaImage.sprite = parrotPrefabList[6].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        OkameImage.sprite = parrotPrefabList[7].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        MomoiroImage.sprite = parrotPrefabList[8].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        OhanaImage.sprite = parrotPrefabList[9].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
        KongoImage.sprite = parrotPrefabList[10].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
    }
}
