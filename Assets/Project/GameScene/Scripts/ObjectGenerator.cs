using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // オブジェクトリスト
    public GameObject[] objectList;
    // 現在のオブジェクト
    private GameObject currentObject;
    // 生成位置
    private Vector2 spawnPosition = new Vector2(0, 2);

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
        currentObject.GetComponent<Rigidbody2D>().gravityScale = 0;
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
            // 現在のオブジェクトをリセット
            currentObject = null;
            // 次のオブジェクトを0.5秒後に生成
            Invoke("GenerateRandomObject", 0.5f);
        }
    }
}
