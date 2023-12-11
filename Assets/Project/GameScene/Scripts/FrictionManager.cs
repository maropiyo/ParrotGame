using UnityEngine;

public class FrictionManager : MonoBehaviour
{
    private Rigidbody2D rb;
    // 動的摩擦係数
    public float dynamicFriction = 0.3f;
    // 静止摩擦係数
    public float staticFriction = 0.001f;
    // 静止時間を測るタイマー
    private float staticTimer = 0f;
    // 静止時間の閾値
    public float staticThreshold = 0.1f;
    private PhysicsMaterial2D physicsMaterial2D;

    void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
        // 物体のPhysicsMaterial2Dを取得
        physicsMaterial2D = rb.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // 静止摩擦と動的摩擦を切り替える
        ChangeFriction();
    }

    // 衝突した時に呼ばれる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトとの摩擦係数を乗算
        physicsMaterial2D.friction *= collision.gameObject.GetComponent<FrictionManager>().physicsMaterial2D.friction;
    }

    // 静止摩擦と動的摩擦を切り替える
    void ChangeFriction()
    {
        // 物体が静止している場合
        if (IsObjectStatic())
        {
            // 静止摩擦を設定
            physicsMaterial2D.friction = staticFriction;
        }
        // 物体が動いている場合
        else
        {
            // 動的摩擦を設定
            physicsMaterial2D.friction = dynamicFriction;
        }
        // 物体のPhysicsMaterial2Dを更新
        rb.sharedMaterial = physicsMaterial2D;
    }

    // 物体が静止しているかどうかを判定する
    bool IsObjectStatic()
    {
        // 物体の速度が0.1以下の場合
        if (rb.velocity.magnitude < 0.1f)
        {
            // 静止時間を計測する
            staticTimer += Time.deltaTime;
        }
        // 物体の速度が0より大きい場合
        else
        {
            // 静止時間をリセットする
            staticTimer = 0f;
        }
        // 静止時間が閾値を超えた場合
        if (staticTimer >= staticThreshold)
        {
            // 静止していると判定する
            return true;
        }
        // 静止していないと判定する
        return false;
    }
}
