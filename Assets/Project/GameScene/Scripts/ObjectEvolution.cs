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

    void Start()
    {
        // ScoreManagerコンポーネントのScoreManagerコンポーネントを取得
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        // SoundEffectManagerオブジェクトのSoundEffectPlayerコンポーネントを取得
        soundEffectPlayer = GameObject.Find("SoundEffectManager").GetComponent<SEPlayer>();
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
            Destroy(collision.gameObject);

            // まだ進化していない場合は進化させる
            if (isEvolved == false && collision.gameObject.GetComponent<ObjectEvolution>().isEvolved == false)
            {
                // 進化フラグをTrueにする
                isEvolved = true;
                // 接触したオブジェクトがコンゴウインコ以外の場合
                if (!collision.gameObject.CompareTag("Kongo"))
                {
                    // 進化後のオブジェクトを衝突したオブジェクトの間に生成
                    Instantiate(nextObjectPrefab, (transform.position + collision.gameObject.transform.position) / 2, Quaternion.identity);
                }
                // 進化時の効果音を鳴らす
                soundEffectPlayer.PlayEvolutionSound();
                // スコアを加算する
                scoreManager.addScore(tag);
            }
        }
    }
}