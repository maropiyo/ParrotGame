using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGenerator : MonoBehaviour
{
    // オブジェクトリスト
    public GameObject[] objectList;
    // 生成済みオブジェクトキュー
    [SerializeField]
    private List<GameObject> generatedObjectQueue;
    // 現在のオブジェクト
    public GameObject currentObject;
    // 次のオブジェクト
    public GameObject nextObject;
    // 卵のスプライト
    public Sprite egg;
    // 割れた卵のスプライト
    public Sprite brokenEgg;
    // 生成位置
    private Vector2 spawnPosition = new Vector2(0, 3.0f);
    // Playerオブジェクト
    private GameObject player;
    // オートモードトグル
    public Toggle autoModeToggle;


    void Start()
    {
        // Playerオブジェクトを取得
        player = GameObject.Find("Player");

        while (generatedObjectQueue.Count < 3)
        {
            // ランダムなオブジェクトを生成してキューに追加
            generatedObjectQueue.Add(GenerateRandomObject());
        }
        // 次のオブジェクトをセット
        nextObject = generatedObjectQueue[0];
        // キューの最初のオブジェクトをスポーン
        SpawnObject(generatedObjectQueue[0]);
        // キューの先頭のオブジェクトを削除
        generatedObjectQueue.RemoveAt(0);
    }

    void Update()
    {
        // 生成済みオブジェクトキューの要素が3未満の場合
        if (generatedObjectQueue.Count < 3)
        {
            // ランダムなオブジェクトを生成してキューに追加
            generatedObjectQueue.Add(GenerateRandomObject());
        }
        nextObject = generatedObjectQueue[0];

        // デバッグ用
        if (autoModeToggle.isOn)
        {
            DropCurrentObject();
        }
    }

    /// <summary>
    /// オブジェクトをランダムに生成する
    /// </summary>
    private GameObject GenerateRandomObject()
    {
        // オブジェクトリストからランダムに1つのオブジェクトを返す。
        return objectList[Random.Range(0, objectList.Length)];
    }

    /// <summary>
    /// オブジェクトをスポーンさせる。
    /// </summary>
    /// <param name="spawnObject"></param>
    private void SpawnObject(GameObject spawnObject)
    {
        // スポーン位置を設定
        spawnPosition = new Vector2(player.transform.position.x, player.transform.position.y + 0.1f);
        currentObject = Instantiate(spawnObject, spawnPosition, Quaternion.identity);
        // 現在のオブジェクトをPlayerオブジェクトの子要素にする
        currentObject.transform.parent = player.transform;
        // 重力を無効化
        currentObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        // 当たり判定を無効化
        Collider2D[] colliders = currentObject.GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders) collider.enabled = false;
        // キューの先頭のオブジェクトを削除
        generatedObjectQueue.RemoveAt(0);
    }


    /// <summary>
    /// オブジェクトを落下させる
    /// </summary>
    public void DropCurrentObject()
    {
        if (currentObject)
        {
            // 重力を有効化
            currentObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            // 当たり判定を有効化
            Collider2D[] colliders = currentObject.GetComponents<Collider2D>();
            foreach (Collider2D collider in colliders) collider.enabled = true;
            // playerオブジェクトとの親子関係を解除
            currentObject.transform.parent = null;
            // 現在のオブジェクトをリセット
            currentObject = null;
            // 4秒待つ
            StartCoroutine(WaitAndSpawn(0.4f));
        }
    }
    IEnumerator WaitAndSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // キューの最初のオブジェクトをスポーン
        SpawnObject(generatedObjectQueue[0]);
    }
}
