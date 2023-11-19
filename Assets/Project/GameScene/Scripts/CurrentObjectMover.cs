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
    // ドラッグ中か
    private bool isDragging = false;

    void Update()
    {
        // ドラッグ開始
        if (currentObject != null && Input.GetMouseButtonDown(0))
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            objectStartPos = currentObject.transform.position;
            isDragging = true;
        }
        // ドラッグ中
        if (isDragging && Input.GetMouseButton(0))
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;
            float newX = Mathf.Clamp(objectStartPos.x + offset.x, -2.7f, 2.7f);
            currentObject.transform.position = new Vector3(newX, objectStartPos.y, objectStartPos.z);
        }
        // ドラッグ終了
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}

