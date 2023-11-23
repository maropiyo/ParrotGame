using UnityEngine;

public class CurrentObjectMover : MonoBehaviour
{
    // 現在のオブジェクト
    public GameObject currentObject = null;

    // 現在のオブジェクトの半分大きさ
    private float halfObjectRadius;

    // ドラッグ開始位置
    private Vector3 touchStartPos;

    // オブジェクトの初期位置
    private Vector3 objectStartPos;

    // 左制限
    private float leftLimit = -2.69f;

    // 右制限
    private float rightLimit = 2.69f;

    // ドラッグ中か
    private bool isDragging = false;

    void Update()
    {
        if (currentObject)
        {
            // オブジェクトの半径を計算
            CalculateObjectRadius();

            if (Input.GetMouseButtonDown(0))
            {
                // ドラッグ開始
                OnDragStart();
            }
            else if (isDragging && Input.GetMouseButton(0))
            {
                // ドラッグ中
                OnDragging();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // ドラッグ終了
                OnDragEnd();
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
        // ドラッグ中フラグを有効にする
        isDragging = true;
    }

    private void OnDragEnd()
    {
        // ドラッグ中フラグを無効にする
        isDragging = false;
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
