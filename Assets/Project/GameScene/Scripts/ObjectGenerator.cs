using UnityEngine;
using UnityEngine.UI;

public class ObjectGenerator : MonoBehaviour
{
    // オブジェクトリスト
    public GameObject[] objectList;
    // 現在のオブジェクト
    private GameObject currentObject;
    // 生成位置
    private Vector2 spawnPosition = new Vector2(0, 3.0f);
    // オートモードトグル
    public Toggle autoModeToggle;


    void Start()
    {
        GenerateRandomObject();
    }

    void Update()
    {
        if (autoModeToggle.isOn)
        {
            DropObject();
        }
    }

    /// <summary>
    /// オブジェクトをランダムに生成する
    /// </summary>
    void GenerateRandomObject()
    {
        // ランダムでオブジェクトを選択して生成
        int randomIndex = Random.Range(0, objectList.Length);
        currentObject = Instantiate(objectList[randomIndex], spawnPosition, Quaternion.identity);
        // 重力を無効化
        currentObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        // 当たり判定を無効化
        Collider2D[] colliders = currentObject.GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders) collider.enabled = false;
        GetComponent<CurrentObjectMover>().currentObject = currentObject;
    }

    /// <summary>
    /// オブジェクトを落下させる
    /// </summary>
    public void DropObject()
    {
        if (currentObject != null)
        {
            // 重力を有効化
            currentObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            // 当たり判定を有効化
            Collider2D[] colliders = currentObject.GetComponents<Collider2D>();
            foreach (Collider2D collider in colliders) collider.enabled = true;
            // 現在のオブジェクトをリセット
            currentObject = null;
            GetComponent<CurrentObjectMover>().currentObject = null;
            // 0.4秒後にオブジェクトを生成
            Invoke("GenerateRandomObject", 0.4f);
        }
    }
}
