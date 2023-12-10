using UnityEngine;

public class RankingManager : MonoBehaviour
{
    // ランキングポップアップ
    public GameObject RankingPopup;
    // RankingNodeの親オブジェクト
    public GameObject rankingParent;
    // RankingNodeのPrefab
    public GameObject rankingNodePrefab;

    /// ランキングポップアップを表示する。
    public void ShowRankingPopup()
    {
        // リーダーボードを取得する。
        PlayFabController.Instance.GetLeaderboard();
        // ランキングポップアップを表示する。
        RankingPopup.SetActive(true);
    }

    /// ランキングポップアップを閉じる
    public void CloseRankingPopup()
    {
        // ランキングポップアップを非表示にする。
        RankingPopup.SetActive(false);

        // RankingNodeを全て削除する。
        ClearRankingNodes();
    }

    /// ランキングノードを全て削除する。
    public void ClearRankingNodes()
    {
        // RankingNodeを全て削除する。
        foreach (Transform child in rankingParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// RankingNodeを生成する。
    /// </summary>
    /// <param name="rank"></param>
    /// <param name="displayName"></param>
    /// <param name="score"></param>
    public void GenerateRankingNode(string rank, string displayName, string score)
    {
        // RankingNodeのインスタンスを生成する。
        var rankingNode = Instantiate(rankingNodePrefab, rankingParent.transform).GetComponent<RankingNode>();

        // ランクをセットする。
        rankingNode.RankText.text = rank;
        // 表示名をセットする。
        rankingNode.DisplayNameText.text = displayName;
        // スコアをセットする。
        rankingNode.ScoreText.text = score;
    }
}