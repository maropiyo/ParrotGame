using System;
using PlayFab.ClientModels;
using Unity.VisualScripting;
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

    public GameObject parrotColorGridLayout;
    public GameObject parrotColorGridListItem;

    bool isSnapped = false;

    public float snapForce;
    float snapSpeed;

    private int currentParrotIndex;

    private int currentIndex;
    private int colorType;

    private SpriteSet[] mamerurihaSpriteSetsArray;
    private SpriteSet[] botanSpriteSetsArray;
    private SpriteSet[] sazanamiSpriteSetsArray;
    private SpriteSet[] kozakuraSpriteSetsArray;
    private SpriteSet[] sekiseiSpriteSetsArray;
    private SpriteSet[] akikusaSpriteSetsArray;
    private SpriteSet[] shiroharaSpriteSetsArray;
    private SpriteSet[] okameSpriteSetsArray;
    private SpriteSet[] momoiroSpriteSetsArray;
    private SpriteSet[] ohanaSpriteSetsArray;
    private SpriteSet[] kongoSpriteSetsArray;

    private int mamerurihaColor;
    private int botanColor;
    private int sazanamiColor;
    private int kozakuraColor;
    private int sekiseiColor;
    private int akikusaColor;
    private int shiroharaColor;
    private int okameColor;
    private int momoiroColor;
    private int ohanaColor;
    private int kongoColor;


    void Start()
    {
        currentIndex = 0;

        // 左右のPaddingを設定
        horizontalLayoutGroup.padding.left = Mathf.RoundToInt((Screen.width - listItem.rect.width) / 2);
        horizontalLayoutGroup.padding.right = Mathf.RoundToInt((Screen.width - listItem.rect.width) / 2);

        // インコの情報をセットする
        SetParrotInfo();
    }

    // インコの情報をセットする
    private void SetParrotInfo()
    {
        // 各インコのspriteSetを取得
        mamerurihaSpriteSetsArray = parrotPrefabList[0].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        botanSpriteSetsArray = parrotPrefabList[1].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        sazanamiSpriteSetsArray = parrotPrefabList[2].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        kozakuraSpriteSetsArray = parrotPrefabList[3].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        sekiseiSpriteSetsArray = parrotPrefabList[4].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        akikusaSpriteSetsArray = parrotPrefabList[5].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        shiroharaSpriteSetsArray = parrotPrefabList[6].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        okameSpriteSetsArray = parrotPrefabList[7].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        momoiroSpriteSetsArray = parrotPrefabList[8].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        ohanaSpriteSetsArray = parrotPrefabList[9].GetComponent<ParrotSpriteChanger>().spriteSetsArray;
        kongoSpriteSetsArray = parrotPrefabList[10].GetComponent<ParrotSpriteChanger>().spriteSetsArray;

        // 現在の各インコの色を取得
        mamerurihaColor = EasySaveManager.Instance.MamerurihaColor;
        botanColor = EasySaveManager.Instance.BotanColor;
        sazanamiColor = EasySaveManager.Instance.SazanamiColor;
        kozakuraColor = EasySaveManager.Instance.KozakuraColor;
        sekiseiColor = EasySaveManager.Instance.SekiseiColor;
        akikusaColor = EasySaveManager.Instance.AkikusaColor;
        shiroharaColor = EasySaveManager.Instance.ShiroharaColor;
        okameColor = EasySaveManager.Instance.OkameColor;
        momoiroColor = EasySaveManager.Instance.MomoiroColor;
        ohanaColor = EasySaveManager.Instance.OhanaColor;
        kongoColor = EasySaveManager.Instance.KongoColor;

        // UIのインコの画像をセット
        ParrotImageList[0].sprite = mamerurihaSpriteSetsArray[mamerurihaColor].normalSprite;
        ParrotImageList[1].sprite = botanSpriteSetsArray[botanColor].normalSprite;
        ParrotImageList[2].sprite = sazanamiSpriteSetsArray[sazanamiColor].normalSprite;
        ParrotImageList[3].sprite = kozakuraSpriteSetsArray[kozakuraColor].normalSprite;
        ParrotImageList[4].sprite = sekiseiSpriteSetsArray[sekiseiColor].normalSprite;
        ParrotImageList[5].sprite = akikusaSpriteSetsArray[akikusaColor].normalSprite;
        ParrotImageList[6].sprite = shiroharaSpriteSetsArray[shiroharaColor].normalSprite;
        ParrotImageList[7].sprite = okameSpriteSetsArray[okameColor].normalSprite;
        ParrotImageList[8].sprite = momoiroSpriteSetsArray[momoiroColor].normalSprite;
        ParrotImageList[9].sprite = ohanaSpriteSetsArray[ohanaColor].normalSprite;
        ParrotImageList[10].sprite = kongoSpriteSetsArray[kongoColor].normalSprite;
    }

    void Update()
    {
        // 画面の中心に一番近いParrotのインデックスをスクリーンサイズから取得
        currentParrotIndex = Mathf.RoundToInt(0 - content.localPosition.x / listItem.rect.width + horizontalLayoutGroup.spacing);

        if (scrollRect.velocity.magnitude < 600 && !isSnapped)
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

                // 選択中のインコが変わった場合
                if (currentIndex != currentParrotIndex)
                {
                    // グリッドレイアウトの子オブジェクトを削除
                    for (int i = 0; i < parrotColorGridLayout.transform.childCount; i++)
                    {
                        Destroy(parrotColorGridLayout.transform.GetChild(i).gameObject);
                    }
                    currentIndex = currentParrotIndex;
                }
                // 現在のインコの画像のサイズを600にする
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
                int colorLength = parrotPrefabList[currentParrotIndex].GetComponent<ParrotSpriteChanger>().spriteSetsArray.Length;
                // すでに生成されている場合は生成しない
                if (colorLength > parrotColorGridLayout.transform.childCount)
                {
                    // グリッドレイアウトの子オブジェクトを生成
                    for (int i = 0; i < colorLength; i++)
                    {
                        // セルを生成
                        GameObject parrotColorGridListItem = Instantiate(this.parrotColorGridListItem, parrotColorGridLayout.transform);
                        // セルの画像をセット
                        parrotColorGridListItem.GetComponent<Image>().sprite = parrotPrefabList[currentParrotIndex].GetComponent<ParrotSpriteChanger>().spriteSetsArray[i].normalSprite;
                        // セルのボタンタップ時の処理をセット
                        // parrotColorGridListItem.GetComponent<Button>().onClick.AddListener(() => OnTapColorButton(i));
                        // インコの情報をセットする
                        SetParrotInfo();
                    }
                }
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
