using UnityEngine;

public class ObjectEvolution : MonoBehaviour
{
    // 進化後のオブジェクトのタグ
    public string nextObjectTag;
    // 進化後のオブジェクトのPrefab
    public GameObject nextObjectPrefab;
    // すでに進化しているか
    private bool isEvolved = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが同じタグ場合
        if (collision.gameObject.CompareTag(tag))
        {
            // 衝突したオブジェクトを破棄
            Destroy(collision.gameObject);

            // ダチョウ同士の場合は何もしない
            if (collision.gameObject.CompareTag("Ostrich")) return;

            if (isEvolved == false && collision.gameObject.GetComponent<ObjectEvolution>().isEvolved == false)
            {
                isEvolved = true;

                // 進化後のオブジェクトを生成
                Instantiate(nextObjectPrefab, transform.position, Quaternion.identity);
            }
        }

    }
}