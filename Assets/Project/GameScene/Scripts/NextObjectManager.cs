using UnityEngine;
using UnityEngine.UI;

public class NextObjectManager : MonoBehaviour
{
    // Image
    public Image image;
    // 表示するオブジェクト
    private GameObject displayObject;
    // ObjectGenerator
    private ObjectGenerator objectGenerator;


    void Start()
    {
        objectGenerator = GameObject.Find("ObjectManager").GetComponent<ObjectGenerator>();
    }

    void Update()
    {
        if (objectGenerator.nextObject)
        {
            DisplayNextParrot();
        }
    }

    void DisplayNextParrot()
    {
        // 表示するオブジェクトを取得
        displayObject = objectGenerator.nextObject;

        image.sprite = displayObject.GetComponent<SpriteRenderer>().sprite;
    }
}