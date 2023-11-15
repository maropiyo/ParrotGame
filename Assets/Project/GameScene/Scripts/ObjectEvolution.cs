using UnityEngine;

public class ObjectEvolution : MonoBehaviour
{
    // 進化後のオブジェクトのタグ
    public string nextObjectTag;
    // 進化後のオブジェクトのPrefab
    public GameObject nextObjectPrefab;
    // すでに進化しているか
    private bool hasEvolved = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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