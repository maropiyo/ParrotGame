using UnityEngine;

public class ObjectEvolution : MonoBehaviour
{
    // 進化後のオブジェクトのタグ
    public string nextObjectTag;
    // 進化後のオブジェクトのPrefab
    public GameObject nextObjectPrefab;
    // すでに進化しているか(進化後のオブジェクトを2つ生成しないようにするために使う)
    private bool isEvolved = false;
    // 衝突回数(3つ以上のオブジェクトが同時に衝突した時に3つ目以降のオブジェクトに処理を走らせないために使う)
    private int collisionCount = 0;
    // ScoreManagerコンポーネント
    private ScoreManager scoreManager;
    // SoundEffectPlayerコンポーネント
    private SEPlayer soundEffectPlayer;
    // 反発係数
    private float forceCoefficient = 100f;

    void Start()
    {
        // ScoreManagerコンポーネントのScoreManagerコンポーネントを取得
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが同じタグかつ、それぞれのオブジェクトの衝突判定回数が1回以下の場合
        if (collision.gameObject.CompareTag(tag) && collisionCount <= 1 && collision.gameObject.GetComponent<ObjectEvolution>().collisionCount <= 1)
        {
            // 衝突回数をインクリメント
            collisionCount++;
            collision.gameObject.GetComponent<ObjectEvolution>().collisionCount++;

            // 衝突したオブジェクトを破棄
            Destroy(gameObject);
            Destroy(collision.gameObject);

            // まだ進化していない場合は進化させる(接触したオブジェクトの片方のみこの処理を走らせるため)
            if (isEvolved == false && collision.gameObject.GetComponent<ObjectEvolution>().isEvolved == false)
            {
                // 進化フラグをTrueにする
                isEvolved = true;
                // 進化時の効果音を鳴らす
                //SEPlayer.Instance.PlayEvolutionSound();
                // 接触したオブジェクトがコンゴウインコ以外の場合
                if (!collision.gameObject.CompareTag("Kongo"))
                {
                    // 進化後のオブジェクトを生成
                    GameObject newObject = Instantiate(nextObjectPrefab, (transform.position + collision.gameObject.transform.position) / 2, Quaternion.identity);
                    float newObjectRadius = newObject.GetComponent<CircleCollider2D>().radius * newObject.transform.localScale.x;
                    // 進化後のオブジェクトと重なっているオブジェクトを取得
                    foreach (Collider2D collider in Physics2D.OverlapCircleAll(newObject.transform.position, newObjectRadius))
                    {
                        // タグがBoxの場合は何もしない
                        if (collider.gameObject.CompareTag("Box"))
                        {
                            continue;
                        }
                        // 重なっているオブジェクトが自分自身の場合は何もしない
                        if (collider.gameObject == newObject.gameObject)
                        {
                            continue;
                        }

                        // 進化後のオブジェクトの大きさ
                        float newObjectScale = newObject.transform.localScale.x;
                        // 重なっているオブジェクトの大きさ
                        float colliderScale = collider.transform.localScale.x;

                        // 進化後のオブジェクトと重なっているオブジェクトの大きさの差
                        float scaleDifference = Mathf.Abs(newObjectScale - colliderScale);

                        // 小さい方のオブジェクトに力を加える(大きさの差が大きいほど大きな力を加える)
                        if (colliderScale < newObjectScale)
                        {
                            float colliderForce = scaleDifference * forceCoefficient;
                            collider.GetComponent<Rigidbody2D>().AddForce((collider.transform.position - newObject.transform.position) * colliderForce);
                        }
                        else
                        {
                            float newObjectForce = scaleDifference * forceCoefficient;
                            newObject.GetComponent<Rigidbody2D>().AddForce((newObject.transform.position - collider.transform.position) * newObjectForce);
                        }

                        Debug.Log(gameObject + ":" + newObject.gameObject.name + ":" + collider.gameObject.name);
                    }
                    // ベロシティを設定
                    newObject.GetComponent<Rigidbody2D>().velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity + GetComponent<Rigidbody2D>().velocity;
                    // newObjectのサイズを0にする
                    newObject.transform.localScale = Vector3.zero;
                    // 進化後のオブジェクトを徐々に大きくする
                    LeanTween.scale(newObject, nextObjectPrefab.transform.localScale, 0.1f).setEase(LeanTweenType.easeInExpo);
                    // エフェクトを再生
                    ParticleSystem particle = newObject.GetComponent<ParticleSystem>();
                    particle.Play();
                }
                // スコアを加算する
                scoreManager.addScore(tag);
            }
        }
    }
}