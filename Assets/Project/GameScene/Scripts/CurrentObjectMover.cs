using UnityEngine;

public class CurrentObjectMover : MonoBehaviour
{
    // 現在のオブジェクト
    public GameObject currentObject = null;
    // 現在のオブジェクトの半分大きさ
    private float halfScaleX;
    // ドラッグ開始位置
    private Vector3 touchStartPos;
    // オブジェクトの初期位置
    private Vector3 objectStartPos;
    // 左制限
    private float leftLimit = -2.7f;
    // 右制限
    private float rightLimit = 2.7f;
    // ドラッグ中か
    private bool isDragging = false;

    void Update()
    {
        if (currentObject)
        {
            // オブジェクトのスケールとコライダーの半径を掛け合わせることでオブジェクトの半径を計算
            halfScaleX = currentObject.GetComponent<Transform>().localScale.x * currentObject.GetComponent<CircleCollider2D>().radius;
            // ドラッグ開始
            if (Input.GetMouseButtonDown(0))
            {
                OnDragStart();
            }
            // ドラッグ中
            else if (isDragging && Input.GetMouseButton(0))
            {
                OnDragging();
            }
            // ドラッグ終了
            else if (Input.GetMouseButtonUp(0))
            {
                OnDragEnd();
            }
        }
    }

    private void OnDragStart()
    {
        touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        objectStartPos = currentObject.transform.position;
        isDragging = true;
    }

    private void OnDragEnd()
    {
        isDragging = false;
    }

    private void OnDragging()
    {
        // マウスの現在位置と前回の位置の差分を取得し、水平方向の移動量として使用する
        Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;

        // 新しいX座標を計算し、制限内でクランプする
        float newXPos = Mathf.Clamp(objectStartPos.x + offset.x, leftLimit + halfScaleX, rightLimit - halfScaleX);

        // オブジェクトの位置を更新する
        currentObject.transform.position = new Vector3(newXPos, objectStartPos.y, objectStartPos.z);

        // マウスの現在位置を次回の計算のために保存する
        // touchStartPos = Input.mousePosition;

        // Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;
        // float newX = Mathf.Clamp(objectStartPos.x + offset.x, -2.7f, 2.7f);
        // currentObject.transform.position = new Vector3(newX, objectStartPos.y, objectStartPos.z);
    }
}

