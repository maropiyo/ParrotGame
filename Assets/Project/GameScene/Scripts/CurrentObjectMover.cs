using System.Runtime.Serialization;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    // 現在のオブジェクト
    public GameObject currentObject = null;
    // オブジェクトの半径
    private float halfObjectRadius;
    // ドラッグ開始位置
    private Vector3 touchStartPos;
    // オブジェクトの初期位置
    private Vector3 objectStartPos;
    // 左制限
    private float leftLimit = -2.69f;
    // 右制限
    private float rightLimit = 2.69f;
    private ObjectGenerator objectGenerator;

    void Start()
    {
        // ObjectManagerオブジェクトのObjectGeneratorコンポーネントを取得
        objectGenerator = GameObject.Find("ObjectManager").GetComponent<ObjectGenerator>();
    }

    void Update()
    {
        // objectGeneratorコンポーネントから現在のオブジェクトを取得
        currentObject = objectGenerator.currentObject;

        if (currentObject)
        {
            // オブジェクトの半径を計算
            CalculateObjectRadius();

            // タップされた時
            if (Input.GetMouseButtonDown(0))
            {
                OnDragStart();
            }
            else if (Input.GetMouseButton(0))
            {
                // ドラッグ中
                OnDragging();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // ドラッグ終了
            }
        }
    }

    private void CalculateObjectRadius()
    {
        // オブジェクトのスケールとコライダーの半径を掛け合わせることでオブジェクトの半径を計算
        CircleCollider2D collider = currentObject.GetComponent<CircleCollider2D>();
        halfObjectRadius = currentObject.transform.localScale.x * collider.radius;
    }

    private void OnDragStart()
    {
        // ドラッグ開始位置を記録
        touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // オブジェクトの初期位置を記録
        objectStartPos = currentObject.transform.position;

    }

    private void OnDragging()
    {
        // マウスの現在位置と前回の位置の差分を取得し、水平方向の移動量として使用する
        Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;

        // 新しいX座標を計算し、制限内でクランプする
        float newXPos = Mathf.Clamp(objectStartPos.x + offset.x, leftLimit + halfObjectRadius, rightLimit - halfObjectRadius);

        // オブジェクトの位置を更新する
        currentObject.transform.position = new Vector3(newXPos, objectStartPos.y, objectStartPos.z);
    }
}
