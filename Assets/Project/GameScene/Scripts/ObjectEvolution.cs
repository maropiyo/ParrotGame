using UnityEngine;

public class ObjectEvolution : MonoBehaviour
{
    // 進化後のオブジェクトのタグ
    public string nextObjectTag;
    // 進化後のオブジェクトのPrefab
    public GameObject nextObjectPrefab;
    // 現在の操作中のオブジェクトか
    public bool isCurrentObject = false;
    // すでに進化しているか
    private bool hasEvolved = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 現在操作中のオブジェクトの場合は何もしない
        if (isCurrentObject) {
            return;
        }
        // 衝突したオブジェクトが同じタグかつ進化先が指定されている場合
        if (collision.gameObject.CompareTag(tag) && nextObjectPrefab != null)
        {
            // 衝突したオブジェクトを破棄
            Destroy(collision.gameObject);

            if (!hasEvolved)
            {
                // 進化後のオブジェクトを生成
                Instantiate(nextObjectPrefab, transform.position, Quaternion.identity);

                // 接触したオブジェクトに対してすでに進化していることを伝える
                collision.gameObject.GetComponent<ObjectEvolution>().hasEvolved = true;
            }
        }
    }
}