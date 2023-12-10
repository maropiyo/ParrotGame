using System.Runtime.Serialization;
using UnityEngine;

public class NextObjectManager : MonoBehaviour
{
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
        // 既存のオブジェクトがあれば破棄する
        if (displayObject)
        {
            Destroy(displayObject);
        }

        // 既存のUI要素にPrefabを追加
        displayObject = Instantiate(objectGenerator.nextObject, transform.position, Quaternion.identity);
        // 判定を無効化
        displayObject.GetComponent<ObjectPositionChecker>().enabled = false;
        // 重力を無効化
        displayObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        // 当たり判定を無効化
        Collider2D[] colliders = displayObject.GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders) collider.enabled = false;
    }
}