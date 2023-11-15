using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // オブジェクトリスト
    public GameObject[] objectList;
    // 現在のオブジェクト
    private GameObject currentObject;
    // 生成位置
    private Vector2 spawnPosition = new Vector2(0, 2.5f);

    void Start()
    {
        GenerateRandomObject();
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
        currentObject.GetComponent<Collider2D>().enabled = false;
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
            currentObject.GetComponent<Collider2D>().enabled = true;
            // 現在のオブジェクトをリセット
            currentObject = null;
            GetComponent<CurrentObjectMover>().currentObject = null;
            // 0.5秒後にオブジェクトを生成
            Invoke("GenerateRandomObject", 0.5f);
        }
    }
}
