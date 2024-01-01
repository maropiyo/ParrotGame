using System;
using UnityEngine;
using UnityEngine.UI;

public class SnapScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public RectTransform listItem;

    public HorizontalLayoutGroup horizontalLayoutGroup;

    public GameObject[] parrotPrefabList;
    public Text ParrotNameText;
    public string[] ParrotNameList;
    public Text DescriptionText;
    public string[] DescriptionList;
    public Image[] ParrotImageList;

    bool isSnapped = false;

    public float snapForce;
    float snapSpeed;

    private int currentParrotIndex;

    private Sprite[] normalSpriteList = new Sprite[11];
    private Sprite[] gameoverSpriteList = new Sprite[11];

    void Start()
    {
        // 左右のPaddingを設定
        horizontalLayoutGroup.padding.left = Mathf.RoundToInt((Screen.width - listItem.rect.width) / 2);
        horizontalLayoutGroup.padding.right = Mathf.RoundToInt((Screen.width - listItem.rect.width) / 2);

        for (int i = 0; i < parrotPrefabList.Length; i++)
        {
            // インコのスプライトを取得
            normalSpriteList[i] = parrotPrefabList[i].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].normalSprite;
            gameoverSpriteList[i] = parrotPrefabList[i].GetComponent<ParrotSpriteChanger>().spriteSetsArray[0].gameoverSprite;
        }
        // インコの情報をセットする
        SetParrotInfo();
    }

    // インコの情報をセットする
    private void SetParrotInfo()
    {
        // UIのインコの画像をセット
        ParrotImageList[0].sprite = normalSpriteList[0];
        ParrotImageList[1].sprite = normalSpriteList[1];
        ParrotImageList[2].sprite = normalSpriteList[2];
        ParrotImageList[3].sprite = normalSpriteList[3];
        ParrotImageList[4].sprite = normalSpriteList[4];
        ParrotImageList[5].sprite = normalSpriteList[5];
        ParrotImageList[6].sprite = normalSpriteList[6];
        ParrotImageList[7].sprite = normalSpriteList[7];
        ParrotImageList[8].sprite = normalSpriteList[8];
        ParrotImageList[9].sprite = normalSpriteList[9];
        ParrotImageList[10].sprite = normalSpriteList[10];
    }

    void Update()
    {
        // 画面の中心に一番近いParrotのインデックスをスクリーンサイズから取得
        int currentParrotIndex = Mathf.RoundToInt(0 - content.localPosition.x / listItem.rect.width + horizontalLayoutGroup.spacing);

        if (scrollRect.velocity.magnitude < 300 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            content.localPosition = new Vector3(
                Mathf.MoveTowards(content.localPosition.x, 0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)), snapSpeed),
                content.localPosition.y,
                content.localPosition.z);
            if (content.localPosition.x == 0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)))
            {
                isSnapped = true;
                // 現在のインコの画像を大きくサイズを600にする
                ParrotImageList[currentParrotIndex].rectTransform.sizeDelta = new Vector2(600, 600);
                // 現在のインコ以外の画像を小さくサイズを400にする
                for (int i = 0; i < parrotPrefabList.Length; i++)
                {
                    if (i != currentParrotIndex)
                    {
                        ParrotImageList[i].rectTransform.sizeDelta = new Vector2(400, 400);
                    }
                }
                ParrotNameText.text = ParrotNameList[currentParrotIndex];
                DescriptionText.text = DescriptionList[currentParrotIndex];
            }
        }
        else
        {
            isSnapped = false;
            snapSpeed = 0;
        }
    }

    // 1番目のインコがタップされた時
    public void OnTapParrot1()
    {
        currentParrotIndex = 0;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 2番目のインコがタップされた時
    public void OnTapParrot2()
    {
        currentParrotIndex = 1;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 3番目のインコがタップされた時
    public void OnTapParrot3()
    {
        currentParrotIndex = 2;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 4番目のインコがタップされた時
    public void OnTapParrot4()
    {
        currentParrotIndex = 3;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 5番目のインコがタップされた時
    public void OnTapParrot5()
    {
        currentParrotIndex = 4;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 6番目のインコがタップされた時
    public void OnTapParrot6()
    {
        currentParrotIndex = 5;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 7番目のインコがタップされた時
    public void OnTapParrot7()
    {
        currentParrotIndex = 6;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 8番目のインコがタップされた時
    public void OnTapParrot8()
    {
        currentParrotIndex = 7;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 9番目のインコがタップされた時
    public void OnTapParrot9()
    {
        currentParrotIndex = 8;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 10番目のインコがタップされた時
    public void OnTapParrot10()
    {
        currentParrotIndex = 9;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

    // 11番目のインコがタップされた時
    public void OnTapParrot11()
    {
        currentParrotIndex = 10;
        content.localPosition = new Vector3(0 - (currentParrotIndex * (listItem.rect.width + horizontalLayoutGroup.spacing)),
            content.localPosition.y,
            content.localPosition.z);
    }

}
