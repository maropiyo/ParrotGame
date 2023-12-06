using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    // 現在のオブジェクト
    public GameObject currentObject = null;
    // 動かせるか
    public bool canMove = true;
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
        // 動かせるようにする
        canMove = true;
        // ObjectManagerオブジェクトのObjectGeneratorコンポーネントを取得
        objectGenerator = GameObject.Find("ObjectManager").GetComponent<ObjectGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        // objectGeneratorコンポーネントから現在のオブジェクトを取得
        currentObject = objectGenerator.currentObject;

        if (currentObject)
        {
            // オブジェクトの半径を計算
            CalculateObjectRadius();
            if (transform.position.x < leftLimit + halfObjectRadius)
            {
                transform.position = new Vector3(leftLimit + halfObjectRadius, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightLimit - halfObjectRadius)
            {
                transform.position = new Vector3(rightLimit - halfObjectRadius, transform.position.y, transform.position.z);
            }
        }
        // タップされた時
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            OnDragStart();
        }
        else if (Input.GetMouseButton(0) && canMove)
        {
            // ドラッグ中
            OnDragging();
        }
        else if (Input.GetMouseButtonUp(0) && canMove)
        {
            // ドラッグ終了
            OnDragEnd();
        }
    }

    private void CalculateObjectRadius()
    {
        // オブジェクトのスケールとコライダーの半径を掛け合わせることでオブジェクトの半径を計算
        CircleCollider2D collider = currentObject.GetComponent<CircleCollider2D>();
        halfObjectRadius = currentObject.transform.localScale.x * collider.radius * transform.localScale.x;
    }

    // ドラッグ開始時に呼ばれる
    private void OnDragStart()
    {
        // タップされた位置を取得
        touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // オブジェクトをタップしたX座標に移動
        objectStartPos = new Vector3(touchStartPos.x, transform.position.y, transform.position.z);

    }

    private void OnDragging()
    {
        // マウスの現在位置と前回の位置の差分を取得し、水平方向の移動量として使用する
        Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - touchStartPos;

        // 新しいX座標を計算し、制限内でクランプする
        float newXPos = Mathf.Clamp(objectStartPos.x + offset.x, leftLimit + halfObjectRadius, rightLimit - halfObjectRadius);

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
