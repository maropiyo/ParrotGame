using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour
{
    // 現在のオブジェクト
    public GameObject currentObject = null;
    // 動かせるか
    public bool canMove = true;
    // オブジェクトの半径
    private float objectRadius = 0;
    // ドラッグ開始位置
    private Vector3 touchStartPos;
    // オブジェクトの初期位置
    private Vector3 objectStartPos;
    // 左制限
    private float _leftLimit = -2.19f;
    // 右制限
    private float _rightLimit = 2.19f;
    private ObjectGenerator objectGenerator;
    // ドラッグ中か
    private bool isDragging;

    void Start()
    {
        // 動かせるようにする
        canMove = true;
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

            // 左右の制限を超えないようにする
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _leftLimit + objectRadius, _rightLimit - objectRadius), transform.position.y, transform.position.z);
        }
        canMove = true;
        // UIをタップしている場合は処理をしない
        if (EventSystem.current.IsPointerOverGameObject())
        {
            canMove = false;
        }
        // スマホでUIをタップしている場合は処理をしない
        else if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
        {
            canMove = false;
        }

        if (Input.GetMouseButtonDown(0) && canMove)
        {
            // ドラッグ開始時の処理
            OnDragStart();
            isDragging = true;
        }
        if (Input.GetMouseButton(0) && isDragging && canMove)
        {
            // ドラッグ時の処理
            OnDragging();
        }
        if (Input.GetMouseButtonUp(0) && isDragging && canMove)
        {
            // ドラッグ終了時の処理
            OnDragEnd();
            isDragging = false;
        }
    }

    private void CalculateObjectRadius()
    {
        // オブジェクトのスケールとコライダーの半径を掛け合わせることでオブジェクトの半径を計算
        CircleCollider2D collider = currentObject.GetComponent<CircleCollider2D>();
        objectRadius = currentObject.transform.localScale.x * collider.radius * transform.localScale.x;
    }

    // ドラッグ開始時に呼ばれる
    private void OnDragStart()
    {
        // タップされた位置を取得
        touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // オブジェクトをタップしたX座標に移動

        objectStartPos = new Vector3(Mathf.Clamp(touchStartPos.x, _leftLimit + objectRadius, _rightLimit - objectRadius), transform.position.y, transform.position.z);
        transform.position = objectStartPos;

    }

    private void OnDragging()
    {
        // マウスの現在位置と前回の位置の差分を取得し、水平方向の移動量として使用する
        Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;

        // 新しいX座標を計算し、制限内でクランプする
        float newXPos = Mathf.Clamp(objectStartPos.x + offset.x, _leftLimit + objectRadius, _rightLimit - objectRadius);

        // オブジェクトの位置を更新する
        transform.position = new Vector3(newXPos, objectStartPos.y, objectStartPos.z);
    }

    // ドラック終了時に呼ばれる
    private void OnDragEnd()
    {
        // 現在のオブジェクトを落下させる
        objectGenerator.DropCurrentObject();
    }
}
