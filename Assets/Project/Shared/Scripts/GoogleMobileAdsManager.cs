using System;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoogleMobileAdsManager : MonoBehaviour
{
    /// プラットフォームごとの広告ユニットID
#if UNITY_ANDROID
    // バナー広告のテスト用ユニットID
    private string _bannerUnitId = "ca-app-pub-3940256099942544/6300978111";
    // インタースティシャル広告のテスト用ユニットID
    private string _interstitialUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
    // バナー広告のテスト用ユニットID
    private string _bannerUnitId = "ca-app-pub-3940256099942544/2934735716";
    // インタースティシャル広告のテスト用ユニットID
    private string _interstitialUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
    private string _bannerUnitId = "unexpected_platform";
    private string _interstitialUnitId = "unexpected_platform";
#endif
    // バナーの広告ビュー
    private BannerView _bannerView;
    // インタースティシャル広告
    private InterstitialAd _interstitialAd;

    // シングルトンパターンの実装
    public static GoogleMobileAdsManager Instance;

    void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(gameObject);

            // シーンがロードされたときのイベントに登録
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 新しいシーンがロードされたらバナー広告を再度表示する
        LoadBannerView();
    }

    void Start()
    {
        // Google Mobile Ads SDKを初期化する。
        MobileAds.Initialize(initStatus =>
        {
            // SDKの初期化が完了したら、広告をロードする。
            LoadBannerView();
        });
    }

    /// <summary>
    /// バナー広告をロードする。
    ///
    public void LoadBannerView()
    {
        // バナー広告を作成する。
        if (_bannerView == null)
        {
            CreateBannerView();
        }

        // 広告リクエストを作成する。
        var adRequest = new AdRequest();

        // 広告をロードする。
        _bannerView.LoadAd(adRequest);
    }

    /// <summary>
    /// バナー広告を作成する。
    /// </summary>
    private void CreateBannerView()
    {
        Debug.Log("バナー広告を作成します。");

        // すでにバナー広告が作成されている場合は、削除する。
        if (_bannerView != null)
        {
            DestroyBannerView();
        }

        // バナー広告を作成する。
        _bannerView = new BannerView(_bannerUnitId, AdSize.Banner, AdPosition.Bottom);
    }
    /// <summary>
    ///　バナー広告を削除する。
    /// </summary>
    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    /// <summary>
    /// インタースティシャル広告を表示する。
    /// </summary>
    public void ShowInterstitialAd()
    {
        if (_interstitialAd != null && _interstitialAd.CanShowAd())
        {
            Debug.Log("インタースティシャル広告を表示します。");
            // インタースティシャル広告を表示する。
            _interstitialAd.Show();
        }
        else
        {
            Debug.Log("インタースティシャル広告の準備ができていません。");
        }
    }

    /// <summary>
    /// インタースティシャル広告をロードする。
    /// </summary>
    public void LoadInterstitialAd()
    {
        // すでにインタースティシャル広告が作成されている場合は、削除する。
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("インタースティシャル広告をロードします。");

        // 広告リクエストを作成する。
        var adRequest = new AdRequest();

        // 広告をロードする。
        InterstitialAd.Load(_interstitialUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // エラーが発生した場合は、広告を作成しない。
                if (error != null || ad == null)
                {
                    Debug.LogError("インタースティシャル広告のロードに失敗しました。¥n" + error);
                    return;
                }
                // 広告のロードが完了したら、インタースティシャル広告を表示する。
                _interstitialAd = ad;
            });
    }

    ///　インタースティシャル広告が閉じられた時に呼ばれる。
    private void OnInterstitialAdClosed(object sender, System.EventArgs e)
    {
        // インタースティシャル広告を削除する。
        _interstitialAd.Destroy();
    }
}

