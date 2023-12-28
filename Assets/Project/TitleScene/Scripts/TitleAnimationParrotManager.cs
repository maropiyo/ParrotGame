using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimationParrotManager : MonoBehaviour
{
    // インコのオブジェクト1
    public GameObject parrot1;
    // インコのオブジェクト2
    public GameObject parrot2;
    // インコのオブジェクト3
    public GameObject parrot3;

    // インコのオブジェクト1のスプライトリスト
    public Sprite[] parrot1SpriteList;
    // インコのオブジェクト2のスプライトリスト
    public Sprite[] parrot2SpriteList;
    // インコのオブジェクト3のスプライトリスト
    public Sprite[] parrot3SpriteList;

    void Start()
    {
        // インコのオブジェクト1のスプライトを変更
        ChangeParrot1Sprite();
        // インコのオブジェクト2のスプライトを変更
        ChangeParrot2Sprite();
        // インコのオブジェクト3のスプライトを変更
        ChangeParrot3Sprite();
    }

    // インコのオブジェクト1のスプライトを変更
    public void ChangeParrot1Sprite()
    {
        // インコのオブジェクト1のスプライトリストからランダムにスプライトを取得
        Sprite randomSprite = parrot1SpriteList[Random.Range(0, parrot1SpriteList.Length)];
        // インコのオブジェクト1のスプライトを変更
        parrot1.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

    // インコのオブジェクト2のスプライトを変更
    public void ChangeParrot2Sprite()
    {
        // インコのオブジェクト2のスプライトリストからランダムにスプライトを取得
        Sprite randomSprite = parrot2SpriteList[Random.Range(0, parrot2SpriteList.Length)];
        // インコのオブジェクト2のスプライトを変更
        parrot2.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

    // インコのオブジェクト3のスプライトを変更
    public void ChangeParrot3Sprite()
    {
        // インコのオブジェクト3のスプライトリストからランダムにスプライトを取得
        Sprite randomSprite = parrot3SpriteList[Random.Range(0, parrot3SpriteList.Length)];
        // インコのオブジェクト3のスプライトを変更
        parrot3.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
